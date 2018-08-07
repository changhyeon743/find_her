using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarController : MonoBehaviour {
	
	public GameObject targetObj;
	public float maxHP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = Camera.main.WorldToScreenPoint(targetObj.transform.position);
		GetComponent<RectTransform>().position = new Vector2(targetPos.x,targetPos.y+100);
		if(targetObj.name == "Player"){
			GetComponent<Image>().fillAmount = Global.gameController.global.hp / maxHP;
			if (Global.gameController.global.hp < 0) {
				Destroy(this.gameObject);
			}
		}
		else if (targetObj.name != "Marfia_gun"){
			GetComponent<Image>().fillAmount = targetObj.GetComponent<Marfia_knife>().hp / maxHP;
			if (targetObj.GetComponent<Marfia_knife>().hp < 0) {
				Destroy(this.gameObject);
			}
		} else {
			GetComponent<Image>().fillAmount = targetObj.GetComponent<Marfia_gun>().hp / maxHP;
			if (targetObj.GetComponent<Marfia_gun>().hp < 0) {
				Destroy(this.gameObject);
			}
		}
	}
}
