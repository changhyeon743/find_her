using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterDB;
//[System.Serializable]
public class Marfia_knife : Marfia_Base {

    public float hp;

    //public float stime = 0.0f;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        srenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        StartCoroutine(RandDir());
        StartCoroutine(SetTarget());
	}

    // Update is called once per frame
    void Update(){
        SetState();
        SetBehaviour();
        Attack();
    }

	public override void Attack()
	{
        if(monsterState == MonsterState.Attack){
            Damage();
        }
        else{
            //
        }
        //base.Attack();
	}

    public void HPMinus(float amount) {
        hp-=amount;
        if (hp < 0) {
            StartCoroutine(Flash());
        }
    }

    public void Damage(){
        if(stime < 1.0f){
                stime+=Time.deltaTime;
            }
            else{
                Global.gameController.global.playerController.MinusHP(1.5f);
                //Global.gameController.global.hp-=1.5f;
                stime = 0.0f;
            }
    }

     IEnumerator Flash(){
        int count=0;
        while(count++ < 10){
            if(count % 2 == 0){
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
            }
            else{
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            }
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(this.gameObject);
    }
}
