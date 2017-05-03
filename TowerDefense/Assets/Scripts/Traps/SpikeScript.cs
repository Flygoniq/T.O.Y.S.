using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {
	float timer;
	float cooldown;
	int riseCounter;
	int fallCounter;

	// Use this for initialization
	void Awake () {
		timer = 0;
		cooldown = 5;
		riseCounter = 0;
		fallCounter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;

		if (riseCounter > 0) {
			if (riseCounter == 1) {
				transform.GetChild (0).GetComponent<SpikeDamageScript> ().gameObject.SetActive (true);
				fallCounter = 10;
			}
			transform.Translate (new Vector3 (0, .3f, 0));
			riseCounter--;
		}
		if (fallCounter > 0) {
			if (fallCounter == 8) {
				transform.GetChild (0).GetComponent<SpikeDamageScript> ().gameObject.SetActive (false);
			}
			transform.Translate (new Vector3 (0, -.09f, 0));
			fallCounter--;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "enemy" && timer >= cooldown) {
			riseCounter = 3;
			timer = 0;
		}
	}
}
