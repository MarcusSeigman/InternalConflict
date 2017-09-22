using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDataHolder : MonoBehaviour {


    public int FatCount;
    public int MeatCount;
    public int BoneCount;
    public int health;


    public float timeLeft = 120.0f;
    public Text Text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        //Text.text = "Time Left : " + Mathf.Round(timeLeft);

        if (Input.GetKeyDown(KeyCode.P))
        {
            timeLeft -= 10;
        }
        if (timeLeft <= 0)
        {
            print("Timer is donerino");
            timeLeft = 0;
        }
    }


}
