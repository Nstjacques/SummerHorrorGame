using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public int inventorySlots;
	public float currentWeight;
	public int score;
	private ItemAttribute itemAttribute;
	public GameObject[] arrayOfObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddObject(GameObject item) {
		itemAttribute = item.GetComponent<ItemAttribute> ();
		currentWeight -= itemAttribute.Weight;
		score += itemAttribute.Value;
		Debug.Log (currentWeight);
		Debug.Log (score);
	}
}
