using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public bool isHeart;
    public bool isPlayer;
    public bool isEnemy;
    public bool isFat;
    public bool isMeat;
    public bool isBone;

    public int maxHealth;
    public int curHealth;

	// Use this for initialization
	void Start () {
        if (isPlayer)
        {
            maxHealth = GameObject.FindObjectOfType<PlayerDataHolder>().GetComponent<PlayerDataHolder>().health;
        }
        if(isEnemy)
        {
            maxHealth = Mathf.FloorToInt( maxHealth * GameObject.FindObjectOfType<EnemyDataHolder>().GetComponent<EnemyDataHolder>().multiplier);
        }
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (curHealth <= 0)
        {
            Death();
        }
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    public void ChangeHealth(int ChangeValue)
    {
        curHealth += ChangeValue;
        
    }

    public void Death()
    {
        if(isHeart)
        {
            Debug.Log("the heart has died");
        }
        if(isFat)
        {
            GameObject.FindObjectOfType<PlayerDataHolder>().GetComponent<PlayerDataHolder>().FatCount++;
            Destroy(gameObject);
        }
        if(isMeat)
        {
            GameObject.FindObjectOfType<PlayerDataHolder>().MeatCount++;
            Destroy(gameObject);
        }
        if(isBone)
        {
            GameObject.FindObjectOfType<PlayerDataHolder>().BoneCount++;
            Destroy(gameObject);
        }
    }
}
