using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmyMan : MonoBehaviour {

	NavMeshAgent agent;
	Animator anim;
	string state; //default is heading for exit, aggressive is attacking player
	int HP;
	float timer;

	Transform player;
	public Transform goal;

	public int maxHP;
	public float aggrodist; //distance at which enemy targets players instead
	public float leashdist; //distance at which enemy returns to default behaviour
	public int power = 1;
	public float timeBetweenAttacks = 1.5f;

	// Use this for initialization
	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Forward", 1);
		state = "default";
		HP = maxHP;
		timer = 0;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float dist = Vector3.Distance (transform.position, player.position);
		if (dist <= aggrodist) {
			state = "aggressive";
		} else if (dist >= leashdist) {
			state = "default";
		}
		if (state == "aggressive") {
			agent.destination = player.position;
		}
		timer += Time.deltaTime;

	}

	void OnCollisionEnter (Collider other) {
		if (other.gameObject.tag == "Player" && timer >= timeBetweenAttacks) {
			//!!! insert attack here
			timer = 0;
		}
	}
}
