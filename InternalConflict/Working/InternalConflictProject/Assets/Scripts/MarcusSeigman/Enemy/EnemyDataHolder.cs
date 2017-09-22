using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHolder : MonoBehaviour {

    public float multiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        multiplier += Time.deltaTime * .001f;
	}
}
