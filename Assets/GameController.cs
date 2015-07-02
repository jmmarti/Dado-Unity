﻿using UnityEngine;
using System.Collections;
using Data;

public class GameController : MonoBehaviour {

	public string p1_targets = "p1 target";
	public string p2_targets = "p2 target";
	public string p3_targets = "p3 target";
	public string p4_targets = "p4 target";

	int currentPhase = 2;

	Phase[] phases;
	Phase clearFloor;
	Phase incident;
	Phase targetSearch;
	Phase exit;
	int ended;

	// Use this for initialization
	void Start () {
		//define phase parameters for each phase
		clearFloor = new Phase (p1_targets);
		incident = new Phase (p2_targets);
		targetSearch = new Phase (p3_targets);
		exit = new Phase (p4_targets);

		phases = new Phase[]{clearFloor, incident, targetSearch, exit};
		Debug.Log ("phases length: "+phases.Length);
		//start the first phase

		ended = 0;

		StepPhase();

	}

	void Update (){
		if (phases [currentPhase].CheckComplete ()) {
			StepPhase();
		}
	}

	void StepPhase(){
		if (currentPhase < phases.Length - 1) {
			currentPhase++;
			phases [currentPhase].StartPhase ();
			Debug.Log("NEW PHASE : " + currentPhase);
		} else {
//			currentPhase++;
			Debug.Log("calling end game()");
			EndGame();
		}
	}

	void EndGame(){
		//show logs?, move to new scene maybe
		Debug.Log ("endGame() called");
		Debug.Log (ended);
		if (ended == 0) {
					Debug.Log ("GAME OVER MUTHAFUCKA");
			//get all historicaldata components and call write log
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject player in players){
				player.GetComponent<HistoricalData>().export_all_markers_to_csv();
			}

			ended = 1;
		}
	}



	public int getPhase(){
		return currentPhase;
	}

	public int getEnded(){
		return ended;
	}

	public int[] getTargetsHit(){
		return phases [currentPhase].targetsHit;
	}


	class Phase{
		public float timeLimit = 10;
			   float timeStart;

		public string targetTag;
		public GameObject[] targets;
		public int[] targetsHit;
		public int targetsLeft;

		public Phase( string tag ){
			targetTag = tag;
			FindTargets();
		}

		public void StartPhase(){
			timeStart = Time.time;
		}

		public bool CheckComplete(){

			for (int i = 0; i < targets.Length; i++) {

				TriggerTarget t = targets [i].GetComponent<TriggerTarget> ();

				if ( t == null) {
					Debug.Log ("Target " + i + " doesn't have a TriggerTarget");
				}else{

					if(t.isTriggered == true && targetsHit[i] == 0){

						Debug.Log("target triggered");
						targetsHit[i] = 1;
						targetsLeft--;
					}
				}
			}

			//return true if the target was reached or if the time is up (include other failure conditions here)
			if (targetsLeft < 1 || 						//target(s) are found
			    Time.time - timeStart > timeLimit ) {	//timelimit for phase is up
				return true;
			} else {
				return false;
			}
		}

		public void FindTargets(){
			targets = GameObject.FindGameObjectsWithTag (targetTag);
			targetsHit = new int[targets.Length];

			for (int i = 0; i < targetsHit.Length; i++) {
				targetsHit[i] = 0;
			}

			targetsLeft = targets.Length;
		}
	}
}
