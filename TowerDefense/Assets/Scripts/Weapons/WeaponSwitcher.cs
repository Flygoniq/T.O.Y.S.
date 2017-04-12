using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public GameObject sword;
    public static bool swordEquipped;
    public GameObject gun;
    public static bool gunEquipped;

    // Use this for initialization
    void Start () {
        gun.SetActive(true);
        gunEquipped = true;
        sword.SetActive(false);
        swordEquipped = false;


    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1"))
        {
            gun.SetActive(true);
            gunEquipped = true;
            sword.SetActive(false);
            swordEquipped = false;
        }
        if (Input.GetKeyDown("2"))
        {
            gun.SetActive(false);
            gunEquipped = false;
            sword.SetActive(true);
            swordEquipped = true;
        }
    }
}
