using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {
	public float lookSpeed = 5f;
	public float lookDistance = 500f;
	Camera mainCam;
	public GameObject player;
	WeaponSwitcher weaponSwitcher;
	Animator playerAnim;
	void Awake(){
		mainCam = Camera.main;
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			weaponLook ();
		}
	}

	//Make the character look at a forward point from the camera
	void weaponLook()
	{
		
		Transform mainCamT = mainCam.transform;
		Transform pivotT = mainCam.transform;
		Vector3 pivotPos = pivotT.position;
		Vector3 lookTarget = pivotPos + (pivotT.forward * lookDistance);
		Vector3 thisPos = transform.position;
		Vector3 lookDir = lookTarget - thisPos;
		Quaternion lookRot = Quaternion.LookRotation(lookDir);
		lookRot.x = 0;
		lookRot.z = 0;

		Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * lookSpeed);
		transform.rotation = newRotation;
	}
}
