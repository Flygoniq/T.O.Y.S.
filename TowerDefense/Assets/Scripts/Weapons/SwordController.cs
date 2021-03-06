﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

	public float timeBetweenAttack = 0.5f;
	public int damage = 25;
	public GameObject player;


	AudioSource audioWield;
	AudioSource audioSlash;

	float range = 1000f;

	Animator swordAnim;

	float timer = 0;

	int attackableMask;

	Animator playerAnim;
	Animator gunAnim;

	// Use this for initialization
	void Start () {
		attackableMask = LayerMask.GetMask ("Attackable");
		swordAnim = GetComponent<Animator> ();
		AudioSource[] audioSet = GetComponents<AudioSource> ();
		audioWield = audioSet [0];
		audioSlash = audioSet [1];
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(WeaponSwitcher.swordEquipped && Input.GetButton("Fire1") && timer >= timeBetweenAttack && Time.timeScale != 0) {
			Attack ();
		}
		
	}

	void Attack(){
		print (attackableMask);
		swordAnim.SetTrigger("Attack");

		Ray wieldRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit shootHit;

		if(Physics.Raycast (wieldRay, out shootHit, range, attackableMask))
		{
			Debug.Log ("We hit: " + shootHit.collider.name);
			audioSlash.Play ();

			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); //The component, existing or not, will return value, the value there or null.

			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damage, shootHit.point, wieldRay.direction);
			}

		}
		else
		{
			audioWield.Play ();
		}
	}
}
