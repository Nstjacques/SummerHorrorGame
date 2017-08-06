using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	
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
		listofObjects.Add(new Item (itemAttribute.itemName, itemAttribute.Weight, itemAttribute.Value));
		Debug.Log(listofObjects[0]);
		// Change player attributes
		currentWeight -= itemAttribute.Weight;
		score += itemAttribute.Value;
		/* // Debug
		Debug.Log (currentWeight);
		Debug.Log (score); */
	}
}
