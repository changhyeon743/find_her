using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterDB;
//[System.Serializable]
public class Marfia_gun : Marfia_Base {
    public Transform shootPos;
    public GameObject bulletPref;

    private Vector3 sstPos;
    public float hp;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        srenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sstPos = shootPos.transform.localPosition;
        StartCoroutine(SetTarget());
        StartCoroutine(Bullet());
	}

    // Update is called once per frame
    void Update(){
        SetState();
        SetBehaviour();
        SetShootPos();
    }

	public override void Attack()
	{
        CreateBullet();
	}

    void SetShootPos(){
        Debug.Log(direction);
        if(direction > 0){
            shootPos.rotation = Quaternion.Euler(0, 0, 0);
            shootPos.localPosition = sstPos;
        }
        else{
            shootPos.rotation = Quaternion.Euler(0, 180, 0);
            shootPos.localPosition = new Vector3(sstPos.x * -1.0f, sstPos.y, sstPos.z);
        }
    }

	void CreateBullet(){
        GameObject bullet = Instantiate(bulletPref, shootPos.position, shootPos.rotation);
        Destroy(bullet, 3.0f);
    }

    IEnumerator Bullet(){
        Attack();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Bullet());
    }

    public void HPMinus(float amount) {
        hp-=amount;
        if (hp < 0) {
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
        Destroy(this.gameObject);
    }
}
