using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Functions : MonoBehaviour {
	public GameObject ControlsPanelObj;

	/* Main Menu */
	public void PlayGame(){
		SceneManager.LoadScene(1);
	}
	public void ControlsPanel(){
		//	TODO: Find the Controls Panel, set active
		ControlsPanelObj.SetActive(true);
	}

	/* Pause Menu */
	public void Resume(){
		GameObject.Find("Managers/GameManager").GetComponent<GameManager>().Pause();
	}
	public void Restart(){
		// Reloads the current scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void ExittoMain(){
		// Loads Main Menu
		SceneManager.LoadScene(0);
	}

	/* Both */
	public void Quit(){
		Application.Quit();
	}
}
