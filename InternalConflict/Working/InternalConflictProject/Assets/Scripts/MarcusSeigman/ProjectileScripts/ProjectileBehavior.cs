using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    public float flightSpeed;
    public float Damage;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = flightSpeed * transform.forward;
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
