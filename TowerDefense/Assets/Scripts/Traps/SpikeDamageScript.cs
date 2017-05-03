using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamageScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "enemy") {
			ArmyMan enemy = other.GetComponent<ArmyMan> ();
			enemy.TakeDamage (40);
		}
	}
}
