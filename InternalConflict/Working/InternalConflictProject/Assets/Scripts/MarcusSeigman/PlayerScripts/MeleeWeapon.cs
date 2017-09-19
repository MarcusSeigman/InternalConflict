using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public bool IsEnemyWeapon;
    public int Damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (!IsEnemyWeapon)
        {
            if (other.tag == "Resource")
            {
                other.GetComponent<HealthComponent>().ChangeHealth(-4);
            }
        }
    }
}
