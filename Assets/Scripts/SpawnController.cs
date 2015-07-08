﻿using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	GameController gc;
	GameObject[] spawns;

	void Awake (){

		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
		spawns = GameObject.FindGameObjectsWithTag("player_spawn");

//		for (int i = 0; i < spawns.Length; i++) {
//			Debug.Log (spawns [i].name);
//		}

		transform.position = spawns [gc.getCondition()].transform.position;
		transform.rotation = spawns [gc.getCondition()].transform.rotation;

	}

}
