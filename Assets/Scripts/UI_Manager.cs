using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	public GameObject panel;
	public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Message (string message) {
		panel.SetActive(true);
		text.text = message;
		yield return new WaitForSeconds (4);
		panel.SetActive (false);
	}	
}
