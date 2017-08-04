using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public int inventorySlots;
	public float currentWeight;
	public int score;
	private ItemAttribute itemAttribute;
	public GameObject[] arrayOfObjects;
	public GameObject BadItemPrison;
	private Vector3 BadItemPrisonLocation;

	// Use this for initialization
	void Start () {
		arrayOfObjects = new GameObject[inventorySlots];
		BadItemPrisonLocation = BadItemPrison.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddObject(GameObject item) {
		arrayOfObjects.add(item);
		item.transform.position = (BadItemPrisonLocation);
		itemAttribute = item.GetComponent<ItemAttribute> ();
		currentWeight -= itemAttribute.Weight;
		score += itemAttribute.Value;
		Debug.Log (currentWeight);
		Debug.Log (score);
	}
}
