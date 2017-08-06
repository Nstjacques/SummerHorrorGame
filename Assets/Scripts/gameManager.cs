using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Header("Player Data")]
	public bool canClick;
	// public bool hitObject;
	public GameObject currentClick;
	
	[Header("Game Data")]
	public int passcode = 0;

	void Start () {
	}
	void Awake() {
	}
	void Update () {
	}
}
