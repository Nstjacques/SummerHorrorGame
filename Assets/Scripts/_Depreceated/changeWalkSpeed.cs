using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWalkSpeed : MonoBehaviour {

	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T)){
			changeSpeed(1f);
		}	
	}

	private void changeSpeed(float newSpeed){
		controller.m_WalkSpeed -= newSpeed;
	}
}
