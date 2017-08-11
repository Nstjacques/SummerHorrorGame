using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	private GameManager GameManager;
	/* Public */
	public int inventorySlots;
	public float currentWeight;
	public int score;
	public List<Item> listofObjects = new List<Item>();
	public GameObject BadItemPrison;
	
	/* Private */
	private Vector3 BadItemPrisonLocation;
	private ItemAttribute itemAttribute;
	
	void Start () {
		GameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
		BadItemPrisonLocation = BadItemPrison.transform.position;
	}

	void Update () {
		
	}

	public void AddObject(GameObject item) {
		itemAttribute = item.GetComponent<ItemAttribute> ();
		// Move the object to prison
		item.transform.position = (BadItemPrisonLocation);
		// Add the object to invetory list
		// Takes name, weight, and value
		listofObjects.Add(new Item (itemAttribute.itemName, itemAttribute.Weight, itemAttribute.Value, itemAttribute.prefab));
		// Change player attributes, make it's own function?
		currentWeight -= itemAttribute.Weight;
		score += itemAttribute.Value;
		/* // Debug
		Debug.Log (currentWeight);
		Debug.Log (score); 
		Debug.Log(listofObjects.Count);*/
		// Destroy(item);
	}

	public void DropObject(Item item){
		Debug.Log("Yay!");
		// TODO: Destroy the UI instance, or add another delegate?
		// TODO: Update the player's stats

		// This was me trying to instantiate, but it didn't work and that's ok!
		/* Vector3 quick = GameManager.Player.transform.position;
		Instantiate(item.prefab, quick, Quaternion.identity); */

		item.prefab.transform.position = GameManager.Player.transform.position;
		// This needs to be the last line of code!
		listofObjects.Remove(item);
	}
}
