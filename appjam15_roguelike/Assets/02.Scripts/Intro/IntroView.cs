using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ViewState{
	Up,
	Down,
	Action,
	End,
	Idle,
};
public class IntroView : MonoBehaviour {
	
	public ViewState currentVs;
	public Camera mainCamera;
	public float cameraSpeed;
	public GameObject chr;

	void Start () {
		currentVs = ViewState.Up;
	}
	
	void Update () {
		switch(currentVs) {

		case ViewState.Up:
			Vector3 pos1 = mainCamera.transform.position;
			pos1 = new Vector3(pos1.x,pos1.y+cameraSpeed * Time.deltaTime,pos1.z);
			mainCamera.transform.position = pos1;
			if (pos1.y > 3.0f) {
				StartCoroutine(SetState(3f,currentVs));
				currentVs = ViewState.Idle;
			}
		break;

		case ViewState.Down:
			cameraSpeed=3f;
			Vector3 pos2 = mainCamera.transform.position;
			pos2 = new Vector3(pos2.x,pos2.y-cameraSpeed * Time.deltaTime,pos2.z);
			mainCamera.transform.position = pos2;
			if (pos2.y < -1.94f) {
				mainCamera.transform.position = new Vector3(0,-1.94f,pos2.z);
				StartCoroutine(SetState(3f,currentVs));
				currentVs = ViewState.End;
				chr.GetComponent<Animator>().SetBool("camdown",true);
			}
		break;

		case ViewState.Action:
			//Animation
			
			
		break;
		}
		if(chr.transform.position.x > -0.2f){
			
		}
	}

	IEnumerator SetState(float _time, ViewState _state){
		switch(_state){
			case ViewState.Up:
				yield return new WaitForSecondsRealtime(_time);
				currentVs = ViewState.Down;
			break;
			case ViewState.Down:
				yield return new WaitForSecondsRealtime(_time);
				currentVs = ViewState.Action;
			break;
		}
		yield return null;
	}
}
