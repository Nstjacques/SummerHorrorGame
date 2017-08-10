using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	private ReticleRaycast ReticleRaycast;
	
	[Header("Player Data")]
	public bool canClick;
	public GameObject currentClick;
	
	[Header("Game Data")]
	public int passcode = 0;

	void Start () {
		controller = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		ReticleRaycast = Player.GetComponent<ReticleRaycast>();
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Awake() {
	}
	void Update () {
	}

	public void DisablePlayerController(bool status){
		if (status == true){
			controller.enabled = false;
			ReticleRaycast.enabled = false;
			Cursor.lockState = CursorLockMode.Confined;
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
