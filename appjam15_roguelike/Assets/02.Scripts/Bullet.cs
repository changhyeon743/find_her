using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 7.5f, ForceMode2D.Impulse);
	}
	
	
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.CompareTag("Player")){
			collision.gameObject.GetComponent<PlayerController>().MinusHP(1.5f);
			Destroy(gameObject);
		}
	}
}
