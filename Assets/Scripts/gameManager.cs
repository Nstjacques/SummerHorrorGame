using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public bool canClick;
	public bool hitObject;
	public GameObject currentClick;
	public GameObject SecondPersonDrifter;
	private FirstPersonDrifter FirstPersonDrifter;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		FirstPersonDrifter = SecondPersonDrifter.GetComponent<FirstPersonDrifter> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && canClick == true) {
			Destroy (currentClick);
			FirstPersonDrifter.speed -= 3;
			Debug.Log ("Sloth");
		}
	}
}
