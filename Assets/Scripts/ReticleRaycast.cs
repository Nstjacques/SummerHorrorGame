using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/* Hi Nick! This is a script for always running a raycast in FixedUpdate that checks if an object has a tag -
 if it does, then it returns a boolean to a GameManager script as True, so the player can click!"
 Attach this to your main camera object. */

public class ReticleRaycast : MonoBehaviour {

public gameManager gameManager;
public Image AspectRatio;
private Ray theRay;
public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
public int passcode = 0;
public UI_Manager UI_Manager;

void FixedUpdate() 
{	
	RaycastHit hit = new RaycastHit();

	if (Physics.Raycast(transform.position, transform.forward, out hit)){
		gameManager.hitObject = hit.collider.gameObject;
		//print("There is something in front of the object!");
			if (hit.collider.gameObject.tag == "inventoryItem" || hit.collider.gameObject.tag == "safe"){
			//print ("Targetable object found");
			//AspectRatio.rectTransform.localScale = new Vector3(1,1,1);
			gameManager.canClick = true;
				Debug.Log ("Spooky");
				gameManager.currentClick = hit.transform.gameObject;
		}
		else {
			//AspectRatio.rectTransform.localScale = new Vector3(1,1.35f,1);
			gameManager.canClick = false;
		}

			if (Input.GetMouseButtonDown (0) && gameManager.canClick == true && hit.collider.gameObject.tag == "inventoryItem") {
				Destroy(hit.collider.gameObject);
				changeSpeed(0.2f);
		}

			if (Input.GetMouseButtonDown (0) && gameManager.canClick == true && hit.collider.gameObject.tag == "safe") {
				if (passcode == 4) {
					Debug.Log ("Bingo");
				} else {
					StartCoroutine(UI_Manager.Message ("I don't have the entire passcode..."));
				}
			}

			if (Input.GetMouseButtonDown (0) && gameManager.canClick == true && hit.collider.gameObject.tag == "passcode") {
				passcode += 1;
				Destroy(hit.collider.gameObject);
			}
		}
	}



	private void changeSpeed(float newSpeed){
		controller.m_WalkSpeed -= newSpeed;
	}

//	public void Message (string message) {
//		guiText.guiText = message;
//		GetComponent<GUIText>().enabled = true;
//		GetComponent<GUIText>().enabled = false;
//	}	
}