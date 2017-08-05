using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	[Header("UI Fade Time")]
	[SerializeField]
	// I really don't get why this has to be so large, but now it looks okay!
	private float ui_fade_timer = 50f;

	[Header("UI Display Time")]
	[SerializeField]
	private float ui_display_time = 4f;

	[Header("Message")]
	public GameObject panel;
	public Text text;
	
	/* Private */

	void Start () {
		
	}
	
	void Update () {
		
	}

	public IEnumerator Message (string message) {
		text.text = message;
		Image img = panel.GetComponent<Image>();
		panel.SetActive(true);
		img.CrossFadeAlpha(255, ui_fade_timer, true);
		yield return new WaitForSeconds (ui_display_time);
		img.CrossFadeAlpha(0f, ui_fade_timer, true);
		panel.SetActive (false);
	}	
}
