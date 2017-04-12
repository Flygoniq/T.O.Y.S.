using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	float timer;
	public int damage = 25;
	public float range = 100000f;
	int attackableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	public GameObject player;
	Animator playerAnim;
	Animator gunAnim;


	void Awake ()
	{
		attackableMask = LayerMask.GetMask ("Attackable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent <Light> ();
		playerAnim = player.GetComponent<Animator> ();
		gunAnim = GetComponentInParent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0) {
			// Player wants to shoot...so. Shoot.
			Fire ();
		}

		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects ();
		}

	}

	public void DisableEffects ()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Fire() {
		
		Debug.Log ("Firing our gun!");

		playerAnim.SetTrigger ("Shoot");
		gunAnim.SetTrigger ("Shoot");


		timer = 0f;

		gunAudio.Play();

		gunLight.enabled = true;

		gunParticles.Stop (); //To prevent inconsistency
		gunParticles.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);  

		Ray shootRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit shootHit;

//		Transform hitTransform;
//		Vector3   hitPoint;
//
//		hitTransform = FindClosestHitObject(shootRay, out hitPoint);

		if(Physics.Raycast (shootRay, out shootHit, range, attackableMask))
		{
			Debug.Log ("We hit: " + shootHit.collider.name);

			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); //The component, existing or not, will return value, the value there or null.

			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damage, shootHit.point, shootRay.direction);
			}

			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

//		if(hitTransform != null) {
//			Debug.Log ("We hit: " + hitTransform.name);
//
//			// We could do a special effect at the hit location
//			// DoRicochetEffectAt( hitPoint );
//
//			Health h = hitTransform.GetComponent<Health>();
//
//			while(h == null && hitTransform.parent) {
//				hitTransform = hitTransform.parent;
//				h = hitTransform.GetComponent<Health>();
//			}
//
//			// Once we reach here, hitTransform may not be the hitTransform we started with!
//
//			if(h != null) {
//				h.TakeDamage( damage );
//			}
//
//
//		}
//
//		cooldown = fireRate;
	}
//
//	Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint) {
//
//		RaycastHit[] hits = Physics.RaycastAll(ray);
//
//		Transform closestHit = null;
//		float distance = 0;
//		hitPoint = Vector3.zero;
//
//		foreach(RaycastHit hit in hits) {
//			if(hit.transform != this.transform && ( closestHit==null || hit.distance < distance ) ) {
//				// We have hit something that is:
//				// a) not us
//				// b) the first thing we hit (that is not us)
//				// c) or, if not b, is at least closer than the previous closest thing
//
//				closestHit = hit.transform;
//				distance = hit.distance;
//				hitPoint = hit.point;
//			}
//		}
//
//		// closestHit is now either still null (i.e. we hit nothing) OR it contains the closest thing that is a valid thing to hit
//
//		return closestHit;
//
//	}
}
