using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemObject : MonoBehaviour {

	public Items type;

	void Update() {
		if (type == Items.normal) {
			Destroy(this.gameObject);
		}
	}
}
