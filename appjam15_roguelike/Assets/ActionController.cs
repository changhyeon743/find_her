using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionController : MonoBehaviour {
	
	void Update () {
		
	}

	GameObject GetClosestObject(Collider2D[] cols) {
        GameObject closestObject = null;
        foreach (var obj in cols)
        {
            if (obj.gameObject == Global.gameController.global.playerController.gameObject) {
                continue;
            }
            if (obj.gameObject.CompareTag("item")) {
                return obj.gameObject;
            }
            if(closestObject == null)
            {
                closestObject = obj.gameObject;
            }
            //compares distances
            if(Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
            {
                closestObject = obj.gameObject;
            }
        }
        return closestObject;
 	}




    public void ActionPlay() {
        Collider2D[] cols = Physics2D.OverlapCircleAll(Global.gameController.global.playerController.transform.position,4f);
		GameObject obj = GetClosestObject(cols);
        print(obj.gameObject.name);
        if (obj.CompareTag("item")) {
            var temp = Global.gameController.global.itemController.currentItem;
            Global.gameController.global.itemController.currentItem = obj.GetComponent<itemObject>().type;
            obj.GetComponent<itemObject>().type = temp;
            //print("log");
        }
        if (obj.CompareTag("enemy")) {
            if(obj.name == "Marfia_gun"){
                obj.GetComponent<Marfia_gun>().HPMinus(4.0f);
            }
            else{
                obj.GetComponent<Marfia_knife>().HPMinus(4.0f);
            }
        }
        Global.gameController.global.playerController.animator.SetTrigger("Attack");
    }
}
