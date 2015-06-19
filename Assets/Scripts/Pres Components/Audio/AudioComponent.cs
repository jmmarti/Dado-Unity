﻿using UnityEngine;
using System.Collections.Generic;

public class AudioComponent : MonoBehaviour {
	private AudioSource ping;
	private float interval;
	private AudioPingFrequency audio_ping_frequency;
	private AudioPitch audio_pitch;
	private AudioVolume audio_volume;
	private AudioPanning audio_panning;
	
	void Start () {
		audio_ping_frequency = GetComponent<AudioPingFrequency> ();
		audio_pitch = GetComponent<AudioPitch> ();
		audio_volume = GetComponent<AudioVolume> ();
		audio_panning = GetComponent<AudioPanning> ();

		ping = GetComponent<AudioSource> ();
		ping.spatialBlend = 0;
		ping.minDistance = 1;
		ping.maxDistance = 100;

		interval = 1;
		Invoke ("location_ping", interval);

	}
	
	// Update is called once per frame
	void Update () {
	}

	void location_ping(){
//		people = t_data.DirectionVectors ();
//		Debug.Log (people.Length + " players found");
//		Debug.Log (people [0]);
//
////		for (int i = 0; i < people.Length; i++) {
////			Debug.Log (people[i]);
////		}
//
//
//
//		Vector3 ping_location = new Vector3 (1000, 0, 0);
////		try{
////			Debug.Log (people [1]);
////			AudioSource.PlayClipAtPoint (c_0, ping_location);
////		}
////		catch(UnityException e){
////			Debug.Log (e);
////		}
//
//		float distance = Vector3.Distance(people[0], m_Transform.position);
//
//		Vector3 targetDir = people[0] - m_Transform.position;
//		Vector3 forward = m_Transform.forward;
//
////		Debug.Log (targetDir);
////		Debug.Log (forward);
//
//		float angle = Vector3.Angle(targetDir, forward);
//		int angleDir = 0;
//		if (Vector3.Cross (targetDir, forward).y > 0) {
//			angleDir = 1; //looking to the right of the target, pan to the left
//		} else {
//			angleDir = 0; //looking to the left of the target, pan to the right
//		}
//		Debug.Log (angleDir);
//		Debug.Log (angle);
//
//		float angleRadians = angle * Mathf.PI / 180;
//
//		//pan by the sin(angle)
//		float panAmount = Mathf.Sin (angleRadians);
//		if (angleDir != 0) {
//			panAmount = panAmount * -1;
//		}
//		Debug.Log (panAmount);
//		ping.panStereo = panAmount;
//		ping.panStereo = 1;
//
//		ping.pitch = 2.0f - distance / 20;
//		if (ping.pitch < 0) {
//			ping.pitch = 0;
//		}
//
//		Debug.Log (distance);
//		if (distance < 10) {
//			Debug.Log ("near");
////			AudioSource.PlayClipAtPoint (c_0, ping_location);
//			ping.volume = 1;
//		} else if (distance < 50) {
//			Debug.Log ("middle");
////			AudioSource.PlayClipAtPoint (c_50, ping_location);
////			ping.volume = 0.5f;
//			ping.volume = 1.0f - distance / 50;
//		}
//		else{
//			Debug.Log ("far");
////			AudioSource.PlayClipAtPoint (c_100, ping_location);
//			ping.volume = 0.1f;
//		}



		//set ping frequency
		if (audio_ping_frequency != null) {
			interval = audio_ping_frequency.get_interval();
			Debug.Log ("frequency = ");
			Debug.Log (interval);
		} else {
			Debug.Log ("Audio Ping Frequency is disabled");
			interval = 1;
		}

		//set pitch
		if (audio_pitch != null) {
			ping.pitch = audio_pitch.get_pitch();
		} else {
			ping.pitch = 1;
		}

		//set volume
		if (audio_volume != null) {
			ping.volume = audio_volume.get_volume();
		} else {
			ping.volume = 1;
		}

		//set panning
		if (audio_panning != null) {
//			AudioSource.PlayClipAtPoint(ping.clip, audio_panning.get_target_location());
			ping.panStereo = audio_panning.get_panning();
		} else {

		}

		ping.Play ();



		Invoke ("location_ping", interval);

	}
}
