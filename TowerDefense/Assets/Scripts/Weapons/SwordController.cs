using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

	public float timeBetweenAttack = 0.8f;
	public int damage = 25;
	public GameObject player;


	AudioSource audioWield;
	AudioSource audioSlash;

	float range = 1000f;


	float timer = 0;

	int attackableMask;

	Animator playerAnim;
	WeaponSwitcher weaponSwitcher;

	void Awake(){
		attackableMask = LayerMask.GetMask ("Attackable");
		AudioSource[] audioSet = GetComponents<AudioSource> ();
		audioSlash = audioSet [0];
		audioWield = audioSet [1];
		if (!player) {
			Debug.Log ("[SwordSwitcher] Please assign the player");
		}
		playerAnim = player.GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
//		if(WeaponSwitcher.swordEquipped && Input.GetButton("Fire1") && timer >= timeBetweenAttack && Time.timeScale != 0) {

		if(Input.GetButton("Fire1") && timer >= timeBetweenAttack && Time.timeScale != 0) {
			Attack ();
		}
		
	}

	void Attack(){
		
		playerAnim.SetBool ("Shoot", true);

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
		StartCoroutine (StopAttack());

	}
	IEnumerator StopAttack(){
		yield return new WaitForSeconds(0.8f);
		playerAnim.SetBool ("Shoot", false);
	}
}
