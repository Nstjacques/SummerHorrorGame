using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/* Public */
public class ReticleRaycast : MonoBehaviour {
	[Header("Managers")]
	private GameManager GameManager;
	private UI_Manager UI_Manager;
	private InventoryManager InventoryManager;

	[Header("The aspect ratio image")]
	public Image AspectRatio;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	/* Private */
	private Ray theRay;

	// Instead of this having to be set publically, it'll just get it at the beginning of the game!
	void Start(){
		controller = this.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		GameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
		UI_Manager = GameObject.Find("Managers/UI_Manager").GetComponent<UI_Manager>();
		InventoryManager = GameObject.Find("Managers/InventoryManager").GetComponent<InventoryManager>();
	}

	void FixedUpdate() 
	{	
		RaycastHit hit = new RaycastHit();

		// If the raycast hits an object
		if (Physics.Raycast(transform.position, transform.forward, out hit, 2)){
			
			/* If the object it hits is an object that can be picked up or the safe,
			Let the player click on it, and create the aspect ratio effect */
			if (hit.collider.gameObject.tag == "inventoryItem" || hit.collider.gameObject.tag == "safe"){
				// TODO: Fade this aspect ratio effect, maybe by lerping?
				AspectRatio.rectTransform.localScale = new Vector3(1,1.15f,1);
				GameManager.canClick = true;
				// Debug.Log ("Spooky");
			}

				/* If the player clicks an object that can be picked up, add it to the inventory */
				if (Input.GetMouseButtonDown (0) && GameManager.canClick == true && hit.collider.gameObject.tag == "inventoryItem") {
					// GameManager.currentClick = hit.transform.gameObject;
					InventoryManager.AddObject (hit.collider.gameObject);
					changeSpeed(hit.collider.gameObject.GetComponent<ItemAttribute>().Weight);
				}

				/* If the player clicks the safe, check if the player has all 4 pieces of the combination */
				if (Input.GetMouseButtonDown (0) && GameManager.canClick == true && hit.collider.gameObject.tag == "safe") {
					if (GameManager.passcode == 4) {
						Debug.Log ("Bingo");
					} else {
						StartCoroutine(UI_Manager.Message ("I don't have the entire combination..."));
					}
				}

				/* If the player clicks an object tagged "passcode", destroy that object,
				and the player now has part of the passcode! */
				if (Input.GetMouseButtonDown (0) && GameManager.canClick == true && hit.collider.gameObject.tag == "passcode") {
					GameManager.passcode += 1;
					Destroy(hit.collider.gameObject);
				}
		}
		else {
			AspectRatio.rectTransform.localScale = new Vector3(1,1.35f,1);
			GameManager.canClick = false;
		}
	}

	// TODO: Move this method to the gamemanager?
	private void changeSpeed(float newSpeed){
		controller.m_WalkSpeed -= newSpeed;
	}	
}