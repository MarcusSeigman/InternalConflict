using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour {

    public Button EAbility;

  
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { }
        else if (Input.GetKeyDown(KeyCode.E)) { }
        else if (Input.GetKeyDown(KeyCode.R)) { }
        else if (Input.GetKeyDown(KeyCode.F)) { }
        else if (Input.GetKeyDown(KeyCode.C)) { }
    }

}
