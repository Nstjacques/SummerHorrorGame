using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	private GameManager GameManager;
	private UI_Manager UI_Manager;
	/* Public */
	public int inventorySlots = 9;
	public List<Item> listofObjects = new List<Item>();
	public GameObject BadItemPrison;
	
	/* Private */
	private Vector3 BadItemPrisonLocation;
	private ItemAttribute itemAttribute;
	
	void Start () {
		GameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
		UI_Manager = GameObject.Find("Managers/UI_Manager").GetComponent<UI_Manager>();
		BadItemPrisonLocation = BadItemPrison.transform.position;
	}

	void DebugStuff(){
		Debug.Log (GameManager.currentWeight);
		Debug.Log (GameManager.score); 
		Debug.Log (listofObjects.Count);
	}

	public void AddObject(GameObject item) {
		if (GameManager.currentWeight <= GameManager.maximumWeight && inventorySlots != 0){
			itemAttribute = item.GetComponent<ItemAttribute> ();
			// Move the object to prison
			item.transform.position = (BadItemPrisonLocation);
			/* Add the object to inventory list
			Takes name, weight, and value */
			listofObjects.Add(new Item (itemAttribute.itemName, itemAttribute.Weight, itemAttribute.Value, itemAttribute.prefab));
			// Change player attributes, make it's own function?
			inventorySlots -= 1;
			GameManager.currentWeight += itemAttribute.Weight;
			GameManager.score += itemAttribute.Value;
		}
	}

	public void DropObject(Item item, GameObject UI_thing){
		// TODO: Update the player's stats

		item.prefab.transform.position = GameManager.Player.transform.position;

		listofObjects.Remove(item);
		Destroy(UI_thing);
		UI_Manager.objectPanelsThatExist -=1;
	}
}
