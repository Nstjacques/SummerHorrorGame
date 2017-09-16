using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	/* Managers */
	private UI_Manager UI_Manager;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	private ReticleRaycast ReticleRaycast;

	[Header("Clickable Tags")]
	[Tooltip("The tags of objects that can clicked - type EXACTLY")]
	public string[] clickable_tags;
	
	[Header("Player Data")]
	public GameObject Player;
	public bool canClick;
	// public GameObject currentClick;
	
	[Header("Game Data")]
	public int passcode = 0;

	/* Private */
	private bool isPaused = false;

	void Start () {
		UI_Manager = GameObject.Find("Managers/UI_Manager").GetComponent<UI_Manager>();
		// 
		controller = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		ReticleRaycast = Player.GetComponent<ReticleRaycast>();
		//
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void DisablePlayerController(bool status){
		if (status == true){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			controller.enabled = false;
			ReticleRaycast.enabled = false;
		}
		if (status == false){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			controller.enabled = true;
			ReticleRaycast.enabled = true;
		}
	}

	public void Pause(){
		// Debug.Log(isPaused);
		if (isPaused == false){
			isPaused = true;
			UI_Manager.Pause_Menu.SetActive(true);
			DisablePlayerController(true);
		}
		else {
			isPaused = false;
			UI_Manager.Pause_Menu.SetActive(false);
			DisablePlayerController(false);
		}		
	}

	public void GameEndPrompt(bool Bool){
		if (Bool == true){StartCoroutine(GameEnd());}
		else{
			UI_Manager.EndGamePrompt.SetActive(false);
			DisablePlayerController(false);
		}
	}
	private IEnumerator GameEnd(){
		Debug.Log("The game is over!");
		UI_Manager.BlackScreenManager(true);
		yield return null;
	}
}
