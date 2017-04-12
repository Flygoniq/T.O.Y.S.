using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusStats : MonoBehaviour {

    public static int nexusHealth;
    public int startHealth = 20;
    public int damage = 1;

	// Use this for initialization
	void Start () {
        nexusHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        /*if (collision.gameObject.tag == "enemy")
        {
			Debug.Log ("Ouch");
            nexusHealth -= damage;
        }*/
        
    }

	public void TakeDamage (int damage) {
		nexusHealth -= damage;

	}

}
