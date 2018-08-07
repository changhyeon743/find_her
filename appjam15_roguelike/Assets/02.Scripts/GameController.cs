using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
	normal,
	item
}


[System.Serializable]
public class Global {
	public Vector3 chr_dir;
	public float chr_speed;
	public static GameController gameController;
	public PlayerController playerController;
	public PlayerState playerState;
	public ActionController actionController;
	public ItemController itemController;
	public float hp;
}

public class GameController : MonoBehaviour {

	public Global global;

	void Start () {
		if(Global.gameController == null){
			Global.gameController = this;
		}
	}
	
	void Update () {
		
	}
}
