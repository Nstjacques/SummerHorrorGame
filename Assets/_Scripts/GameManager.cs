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
	public float maximumWeight;
	public float currentWeight;
	public int score;
	// public GameObject currentClick;
	
	[Header("Game Data")]
	//In-game Time Count
	public float playTime;
	public bool timeStarted = false;
	// How many cursed items does the player have
	public int cursedItemCount = 0;
	// How many pieces of the passcode does the player have
	public int passcodeCount = 0;

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
		timeStarted = true;
	}
	void Update() {
		playTime += Time.deltaTime;
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
		/* 
		TODO: Fade the screen to black, play a music cue
		Fade up a new canvas element that contains a whole lot of stuff, including
		time, score, how many cursed items, was the "Elixir of Life" found
		*/
		UI_Manager.EndGameMenu.SetActive(true);
		DisablePlayerController(true);
		yield return null;
	}
}