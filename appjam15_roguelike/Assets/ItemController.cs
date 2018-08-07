using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items {
	normal,
	short_sword,
	long_sword,
	normal_gun,
	super_gun
}

public class ItemController : MonoBehaviour {

	public Items currentItem;

	// Use this for initialization
	void Start () {
		currentItem = Items.normal;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<PlayerController>().animator.SetInteger("itemNum",(int)currentItem );
		
	}
}
