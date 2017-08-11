using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : IComparable<Item> {
	public string Name;
	public float Weight;
	public int Value;
	public GameObject prefab;

	public Item (string InName, float InWeight, int InValue, GameObject InPrefab){
		Name = InName;
		Weight = InWeight;
		Value = InValue;
		prefab = InPrefab;
	}

	public int CompareTo(Item other){
		if(other == null){
			return 1;
		}
		return Value - other.Value;
	}
}
