﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(2);
    }
}
