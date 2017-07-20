using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public bool canClick;
	public bool hitObject;
	public GameObject currentClick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && canClick == true) {
			Destroy (currentClick);
		}
	}
}
