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
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	[Header("Raycast Reach")]
	// Use this variable to change how far away from them a player can reach!
	public float raycastReach = 3;

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
		if (Physics.Raycast(transform.position, transform.forward, out hit, raycastReach)){
			
			/* If the object it hits is an object that can be picked up or the safe,
			Let the player click on it, and create the aspect ratio effect */
			if (hit.collider.gameObject.tag == "inventoryItem" || hit.collider.gameObject.tag == "safe" || hit.collider.gameObject.tag == "Door"){
				// TODO: Fade this aspect ratio effect, maybe by lerping?
				UI_Manager.AspectRatio.rectTransform.localScale = new Vector3(1,1.15f,1);
				GameManager.canClick = true;
				UI_Manager.HUD(hit.collider.gameObject.tag);
			}

			if (Input.GetMouseButtonDown (0) && GameManager.canClick == true){
				switch (hit.collider.gameObject.tag){
					case "inventoryItem":
						// GameManager.currentClick = hit.transform.gameObject;
						InventoryManager.AddObject (hit.collider.gameObject);
						// TODO: Move this to Inventory Manager
						changeSpeed(hit.collider.gameObject.GetComponent<ItemAttribute>().Weight);
						break;
					case "safe":
						if (GameManager.passcode == 4) {
							Debug.Log ("Bingo");
							// TODO: open the safe
						} else {
							StartCoroutine(UI_Manager.Message ("I don't have the entire combination..."));
						}
						break;
					case "passcode":
						GameManager.passcode += 1;
						// change to "set active"?
						Destroy(hit.collider.gameObject);
						break;
					case "Door":
						hit.collider.gameObject.SendMessage("Open");
						break;
				}
			}
		}
		else {
			UI_Manager.Verb_Obj.SetActive(false);
			UI_Manager.AspectRatio.rectTransform.localScale = new Vector3(1,1.35f,1);
			GameManager.canClick = false;
		}
	}

	// TODO: Move this method to the gamemanager?
	private void changeSpeed(float newSpeed){
		controller.m_WalkSpeed -= newSpeed;
	}	
}