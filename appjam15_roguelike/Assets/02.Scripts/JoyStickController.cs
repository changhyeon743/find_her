using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour {
	public GameObject _bigJoystickObj;
	private Vector3 _firstPosition;
	private float _joystickRadius;

	


	void Start () {
		_firstPosition = transform.position;
		_joystickRadius = _bigJoystickObj.GetComponent<RectTransform>().rect.width/4;
	}
	

	void Update () {
		
		int touchCount = Input.touchCount;

		

			
			if (touchCount >= 1) {
				

				Touch touch = Input.GetTouch(0);
				Vector2 pos = touch.position;
				
				if (touch.position.x > Screen.width / 2) {
					checkActionButton(0);
					return;
				}

				float touchArea = Vector3.Distance(_firstPosition,new Vector3(pos.x,pos.y));
				Global.gameController.global.chr_dir = (new Vector3(pos.x,pos.y) - _firstPosition).normalized;
				Vector2 touchPositionFix = pos;

				if (touchArea > _joystickRadius)
				touchPositionFix = _firstPosition + Global.gameController.global.chr_dir * _joystickRadius;

				Global.gameController.global.chr_speed = Vector3.Distance(_firstPosition,new Vector3(touchPositionFix.x,touchPositionFix.y));

				transform.position = touchPositionFix; //
				
				if (touch.phase == TouchPhase.Ended) {
					disable();
				}

				if (touchCount == 2) {
					checkActionButton(1);
				} 
			}

		}
	
	void disable() {
		Global.gameController.global.chr_dir = Vector3.zero;
        Global.gameController.global.chr_speed = 0;
        transform.position = _firstPosition;
		Global.gameController.global.playerController.animator.SetFloat("dir_x",0);
	}

	void checkActionButton(int touchIndex) {
		Touch touch2 = Input.GetTouch(touchIndex);
		Ray2D ray = new Ray2D(touch2.position, Vector2.zero);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

		if (hit.collider == null)
		{
			return;
		}
		if(touch2.phase == TouchPhase.Began && hit.collider.gameObject.CompareTag("ActionButton")) {
			Global.gameController.global.actionController.ActionPlay();
		}
	}
	
}
