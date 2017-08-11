using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttribute : MonoBehaviour {
	public float Weight;
	public int Value;
	public string itemName;
	public GameObject prefab;

	void Start(){
		prefab = this.gameObject;
	}
}
