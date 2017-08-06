using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : IComparable<Item> {
	public string Name;
	public float Weight;
	public int Value;

	public Item (string InName, float InWeight, int InValue){
		Name = InName;
		Weight = InWeight;
		Value = InValue;
	}

	public int CompareTo(Item other){
		if(other == null){
			return 1;
		}
		return Value - other.Value;
	}
}
