using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	/* Managers */
	private UI_Manager UI_Manager;

	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	private ReticleRaycast ReticleRaycast;
	
	[Header("Player Data")]
	public bool canClick;
	public GameObject currentClick;
	
	[Header("Game Data")]
	public int passcode = 0;

	/* Private */
	private bool isPaused = false;

	void Start () {
		UI_Manager = GameObject.Find("Managers/UI_Manager").GetComponent<UI_Manager>();
		// 
		GameObject Player = GameObject.Find("FPSController");
		controller = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		ReticleRaycast = Player.GetComponent<ReticleRaycast>();
		// 
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Awake() {
	}
	void Update () {
	
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

	public void DisablePlayerController(bool status){
		if (status == true){
			controller.enabled = false;
			ReticleRaycast.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		if (status == false){
			controller.enabled = true;
			ReticleRaycast.enabled = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
