using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Functions : MonoBehaviour {
	public GameObject ControlsPanelObj;

	// TODO: Make update function that listens for "Cancel" button disables panels if they are active

	/* Main Menu */
	public void PlayGame(){
		SceneManager.LoadScene(1);
	}
	public void ControlsPanel(){
		//	TODO: Find the Controls Panel, set active
		ControlsPanelObj.SetActive(true);
		
	}

	/* Pause Menu */
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
