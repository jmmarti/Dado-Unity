﻿using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public string tag = "player_spawn";
	public string spawnPhase = "awake";

	GameController gc;
	Phase p;
	GameObject[] spawns;

	void Start (){

		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
		spawns = GameObject.FindGameObjectsWithTag(tag);
		
		if(spawnPhase.Equals("awake")){
			transform.position = spawns [gc.getCondition()].transform.position;
			transform.rotation = spawns [gc.getCondition()].transform.rotation;
		}else{
			gc.getPhaseByName(spawnPhase).StartPhase += SetPos;
		}

	}

	void SetPos(){

		Debug.Log("calling exit");

		transform.position = spawns [gc.getCondition()].transform.position;
		transform.rotation = spawns [gc.getCondition()].transform.rotation;

	}

}
