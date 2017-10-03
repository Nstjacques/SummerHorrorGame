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

	[Header("HUD")]
	public Image BlackScreen;
	public Image AspectRatio;
	public GameObject Verb_Obj;
	[HideInInspector]
	public Text Verb_Text;

	[Header("Inventory")]
	public GameObject inventory_panel;
	public GameObject item_panel_prefab;
	public GameObject passcode_status_panel;
	private bool isInventoryOpen;
	[HideInInspector]
	public int objectPanelsThatExist;
	
	[Header("Message")]
	public GameObject panel;
	public Text text;

	[Header("End of Game Prompt")]
	public GameObject EndGamePrompt;

	[Header("End of Game Menu")]
	public GameObject EndGameMenu;

	[Header("Pause Menu")]
	public GameObject Pause_Menu;
	
	/* Private */
	private string weight_str = "Weight: ";
	private string value_str = "Value: ";

	void Start () {
		GameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
		InventoryManager = GameObject.Find("Managers/InventoryManager").GetComponent<InventoryManager>();

		Verb_Text = Verb_Obj.GetComponent<Text>();
		Verb_Text.text = "";
		objectPanelsThatExist = 0;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab)){
			// Debug.Log("Inventory!");
			Inventory();
		}
		if (Input.GetKeyDown(KeyCode.P) | Input.GetKeyDown(KeyCode.Escape)){
			GameManager.Pause();
		}
	}

	public void HUD (string message){
		switch (message){
			case "inventoryItem":
				Verb_Text.text = "Take";
				break;
			case "safe":
				Verb_Text.text = "Open";
				break;
			case "Door":
				Verb_Text.text = "Open";
				break;
			case "FinalDoor":
				Verb_Text.text = "Open";
				break;
		}
		Verb_Obj.SetActive(true);
	}

	public IEnumerator Message (string message) {
		text.text = message;
		Image img = panel.GetComponent<Image>();
		panel.SetActive(true);
		img.CrossFadeAlpha(255, ui_fade_timer, false);
		yield return new WaitForSeconds (ui_display_time);
		img.CrossFadeAlpha(0f, ui_fade_timer, false);
		panel.SetActive (false);
	}

	public void Inventory(){
		/* Instantiate the item panels as giant buttons, 
		so they can be programmed to delete the object it represents and spawn it*/
		if (isInventoryOpen == false){
			isInventoryOpen = true;
			GameManager.DisablePlayerController(true);
			inventory_panel.SetActive(true);
			
			// TODO: Run Function that checks/updates the passcode status?
			passcode_status_panel.SetActive(true);
			
			// Creates new panel objects if you have new items in your inventory
			for (int i = objectPanelsThatExist; i < InventoryManager.listofObjects.Count; i++){
				Item reference = InventoryManager.listofObjects[i];
				
				GameObject Item = Instantiate(item_panel_prefab, inventory_panel.transform);
				
				// Adds listener for deleting objects!
				Button button = Item.GetComponent<Button>();
				button.onClick.AddListener(delegate {InventoryManager.DropObject (reference, Item);});
				
				// Populates the UI with all the important information
				Transform stats_panel = Item.transform.GetChild(0);
				stats_panel.GetChild(0).GetComponent<Text>().text = reference.Name;
				stats_panel.GetChild(1).GetComponent<Text>().text = weight_str + reference.Value.ToString();
				stats_panel.GetChild(2).GetComponent<Text>().text = value_str + reference.Weight.ToString();
				
				// This int tracks how many panels have been made, so it only creates new ones whenever you open the inventory!
				objectPanelsThatExist++;
			}
		}
		else {
			isInventoryOpen = false;
			inventory_panel.SetActive(false);
			passcode_status_panel.SetActive(false);
			GameManager.DisablePlayerController(false);
		}
	}
}