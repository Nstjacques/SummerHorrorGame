using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Hi Nick! This is a script for always running a raycast in FixedUpdate that checks if an object has a tag -
 if it does, then it returns a boolean to a GameManager script as True, so the player can click!"
 Attach this to your main camera object. */

public class ReticleRaycast : MonoBehaviour {

public GameManager gameManager;
public Image AspectRatio;
private Ray theRay;

void FixedUpdate() 
{	
	RaycastHit hit = new RaycastHit();

	if (Physics.Raycast(transform.position, transform.forward, out hit)){
		gameManager.hitObject = hit.collider.gameObject;
		//print("There is something in front of the object!");
		if (hit.collider.gameObject.tag == "Targetable"){
			//print ("Targetable object found");
			AspectRatio.rectTransform.localScale = new Vector3(1,1,1);
			gameManager.canClick = true;
		}
		else {
			AspectRatio.rectTransform.localScale = new Vector3(1,1.35f,1);
			gameManager.canClick = false;
		}
	}
}
}