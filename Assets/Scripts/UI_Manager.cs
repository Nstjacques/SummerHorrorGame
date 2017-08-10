using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	[Header("Managers")]
	private GameManager GameManager;
	private InventoryManager InventoryManager;

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

	[Header("Inventory")]
	public GameObject inventory_panel;
	public GameObject item_panel_prefab;
	public GameObject passcode_status_panel;
	private bool isInventoryOpen;
	private int objectPanelsThatExist;

	[Header("Mouse Control")]
	public CursorLockMode wantedMode;
	
	/* Private */
	private string weight_str = "Weight: ";
	private string value_str = "Value: ";

	void Start () {
		GameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
		InventoryManager = GameObject.Find("Managers/InventoryManager").GetComponent<InventoryManager>();
		objectPanelsThatExist = 0;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.I)){
			Debug.Log("Inventory!");
			Cursor.lockState = wantedMode;
			Inventory();
		}
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

	public void Inventory(){
		// TODO: Lock the mouse so they can click stuff
		/* TODO: Instantiate the item panels as giant buttons, 
		so they can be programmed to delete the object it represents and spawn it*/
		if (isInventoryOpen == false){
			isInventoryOpen = true;
			GameManager.DisablePlayerController(true);
			inventory_panel.SetActive(true);
			// TODO: Run Function that checks/updates the passcode status
			passcode_status_panel.SetActive(true);
			for (int i = objectPanelsThatExist; i < InventoryManager.listofObjects.Count; i++){
				GameObject Item = Instantiate(item_panel_prefab, inventory_panel.transform);
				Button button = Item.GetComponent<Button>();
				button.onClick.AddListener(delegate {InventoryManager.DropObject (i);}); 
				Transform stats_panel = Item.transform.GetChild(0);
				stats_panel.GetChild(0).GetComponent<Text>().text = InventoryManager.listofObjects[i].Name;
				stats_panel.GetChild(1).GetComponent<Text>().text = weight_str + InventoryManager.listofObjects[i].Value.ToString();
				stats_panel.GetChild(2).GetComponent<Text>().text = value_str + InventoryManager.listofObjects[i].Weight.ToString();
				objectPanelsThatExist++;
			}
		}
		else {
			inventory_panel.SetActive(false);
			passcode_status_panel.SetActive(false);
			isInventoryOpen = false;
			GameManager.DisablePlayerController(false);
		}
	}
}