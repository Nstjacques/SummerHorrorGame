﻿using System.Collections;
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
		// Change player attributes, make it's own function?
		currentWeight -= itemAttribute.Weight;
		score += itemAttribute.Value;
		/* // Debug
		Debug.Log (currentWeight);
		Debug.Log (score); 
		Debug.Log(listofObjects.Count);*/
	}

	public void DropObject(Item item){
		Debug.Log("Yay!");
		// This needs to be the last line of code!
		listofObjects.Remove(item);
		Debug.Log(listofObjects.Count);
	}
}
