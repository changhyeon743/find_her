using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _movement;
	public Animator animator;
	public SpriteRenderer srenderer;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		srenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.gameController.global.chr_speed > 0) {
		animator.SetFloat("dir_x",Normalizing(Global.gameController.global.chr_dir.x));

		_movement.x = Global.gameController.global.chr_dir.x;
		_movement.y = Global.gameController.global.chr_dir.y;

		float speed = (Global.gameController.global.chr_speed) * 0.1f;
		
		_movement = _movement.normalized * speed * Time.deltaTime;

		transform.position = transform.position + _movement;

		
		
		}
	}

	

	float Normalizing(float _float) {
		_float = _float >=0 ? 1 : -1;
		if(_float >= 0){
			srenderer.flipX = false;
		}
		else{
			srenderer.flipX = true;
		}

		return _float;
	}

	public void MinusHP(float amount){
		Global.gameController.global.hp-=amount;
		if (Global.gameController.global.hp < 0) {
			
			StartCoroutine(Flash());
		}
	}

	IEnumerator Flash(){
        int count=0;
        while(count++ < 6){
            if(count % 2 == 0){
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
            }
            else{
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            }
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.SetActive(false);
    }
}
