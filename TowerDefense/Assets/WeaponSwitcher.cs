using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public GameObject sword;
    public GameObject gun;

	// Use this for initialization
	void Start () {
        gun.SetActive(true);
        sword.SetActive(false);
            
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1"))
        {
            gun.SetActive(true);
            sword.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            gun.SetActive(false);
            sword.SetActive(true);
        }
    }
}
