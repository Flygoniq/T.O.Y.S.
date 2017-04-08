using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Animator anim;

	private Transform transf;
//	private float fallHeight = 3f; 
	private AnimatorStateInfo currentBaseState;
	private CapsuleCollider col;

	static int idleState = Animator.StringToHash ("Base Layer.Idle");
	static int locoState = Animator.StringToHash ("Base Layer.FwdLocomotion");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
//	static int jump0State = Animator.StringToHash("Base Layer.Jump0");
	static int turnRightState = Animator.StringToHash ("Base Layer.RightTurn");
	static int turnLeftState = Animator.StringToHash ("Base Layer.LeftTurn");


	void Start () {
		// initializing reference variables
		anim = GetComponent<Animator>();
		transf = GetComponent<Transform> ();
		col = GetComponent<CapsuleCollider> ();
		//cc = GetComponent<CharacterController> (); 
	}


	// Update is called once per frame
	void Update () {


		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

//		if (Input.GetKey (KeyCode.LeftShift))
//			locoSpeed = 1f;
//		else
//			locoSpeed = 0.5f;

		//Once the player press W/S, set the speed to be the speed set up.
		float v = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", v);

		//
		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D))
			anim.SetFloat ("Direction", -1.0f);
		else if (!Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D))
			anim.SetFloat ("Direction", 1.0f);
		else
			anim.SetFloat ("Direction", 0.0f);	


		//

		if (Input.GetButtonDown ("Jump")) {
			anim.SetTrigger ("Jump");
			//Translate the transform component.
		}

		else if(currentBaseState.fullPathHash== jumpState)
		{
			//  ..and not still in transition..
			if(!anim.IsInTransition(0))
			{
				// ..set the collider height to a float curve in the clip called ColliderHeight
				col.height = anim.GetFloat("ColliderHeight");
				// reset the Jump bool so we can jump again, and so that the state does not loop 
//				anim.SetBool("Jump", false);
			}
		}

		// Raycast down from the center of the character.. 
//		Ray ray = new Ray(transf.position  + Vector3.up, -Vector3.up);
//		RaycastHit hitInfo = new RaycastHit();
//		//		Debug.DrawRay (transform.position, Vector3.down * fallHeight);
//		if (Physics.Raycast(ray, out hitInfo))
//		{
//			//			Debug.Log (hitInfo.distance);
//			// ..if distance to the ground is more than fallHeight, do falling animation
//			if (hitInfo.distance > fallHeight) {
//				//				Debug.Log (hitInfo.distance);
//				//				Debug.Log (hitInfo.collider);
//				anim.SetBool ("FallDown", true);
//				//anim.applyRootMotion = false;
//			} else if (hitInfo.distance > 1 && hitInfo.distance <= fallHeight) {
//				anim.SetBool ("FallDown", false);
//				anim.SetTrigger ("Roll");
//				anim.MatchTarget (hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask (new Vector3 (0, 1, 0), 0), 0.35f, 0.5f);
//			} else {
//				anim.SetBool ("FallDown", false);
//				//anim.applyRootMotion = true;
//			}
//		}
	}
}
