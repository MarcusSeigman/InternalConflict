/*------------------------------------------------------------------------------------------------
 Author: Marcus Seigman
 Date:   18Sep16
 Credit: Mark Brown's Lecture
 Credit: PGF2 Experiment01 Game Framework
 Credit: PGF2 Experiment02 Interactable Objects
 Credit: PGF2 Experiment03 AI and Polish
 Credit: Camran Gibson
 Credit: Alexandra Rood
 Credit: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
 Credit: https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
 Credit: https://docs.unity3d.com/ScriptReference/Mathf.Sin.html
 Credit: http://answers.unity3d.com/questions/781748/using-mathfsin-to-move-an-object.html
 Credit: http://answers.unity3d.com/questions/265810/limiting-rigidbody-speed.html
 Credit: https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html
 Credit: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
 Credit: https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
 Credit: http://answers.unity3d.com/questions/275343/destroy-parent-of-child-gameobject.html
 Credit: https://docs.unity3d.com/ScriptReference/Quaternion.html
 Credit: http://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
 Credit: https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
 Purpose: The purpose of this script is to control the movement and spawning rate of the enemy generator. 
//------------------------------------------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    //Sets the direction and distance of the generator's movement.
    [SerializeField]
    Vector3 directions = Vector3.zero;
    // Allows the speed at which the generator moves to be set.
    [SerializeField]
    float moveSpeed = 1;

    //used to get the initial position and the offset from the mathf.
    Vector3 initialPos = Vector3.zero;
    Vector3 offset = Vector3.zero;

    //a variable to keep track of time* movespeed
    float moveTime;

    //An array to allow multiple types of enemies to be spawned.
    [SerializeField]
    GameObject[] EnemyTypes;

    //The minimum and maximum time between enemy spawns.
    [SerializeField]
    float TimeMin = 1;
    [SerializeField]
    float TimeMax = 4;

    //variables that are used in the spawning of enemies. One keeps time with time.deltatime, the other is what it is compared to, a random number between time min and time max.
    private float TimeLimit = 0;

    private float Timer = 0;

    //a bool to set the generator to spawn enemies in bursts rather than at a random time.
    [SerializeField]
    bool enemyBurstSpawn = false;

    //the number of enemies spawned in a burst.
    [SerializeField]
    int enemyBurstNumber = 3;

    //the number of enemies spawned in the burst so far, used to count up to the burst number.
    private int enemySpawnNumber = 0;

    // the time between bursts, and the time between each enemy in the burst.
    [SerializeField]
    float burstDelay = 5;
    [SerializeField]
    float burstStagger = .5f;

    public bool waveFighter;
    // Use this for initialization

    void Start () {
        //sets the initial pos, and if it is a burst spawner, starts the spawn count down.
        initialPos = transform.position;
        if (enemyBurstSpawn == true)
        {
            InvokeRepeating("SpawnBurst", burstDelay, burstStagger);
        }
    }
	
	// Update is called once per frame
	void Update () {
        updateTimer();
        //Allows the ping pong movement.
        moveTime += Time.deltaTime * moveSpeed;

        if (directions.x > 0)
        {
            offset.x = Mathf.PingPong(moveTime, directions.x);
        }
        transform.position = initialPos + offset;

        
    }

    void updateTimer()
    {
        //if the generator is not a burst spawner, generates an enemy at a rate based on the min and max times.
        Timer += Time.deltaTime;

        if (enemyBurstSpawn == false) { 
        if (Timer >= TimeLimit)
        {
            TimeLimit = Random.Range(TimeMin, TimeMax);

            Timer = 0;

            doSpawn();
        }
    }
    }

    
    // the function to spawn the enemy types in the enemy type array, when not a burst.
    void doSpawn()
    {
        //Percentage based spawning
        if (!waveFighter)
        {
            int randIndex = Random.Range(0, 100);
            if (randIndex >= 0 && randIndex <= 4)
            {
                Instantiate(EnemyTypes[0], transform.position, transform.rotation);
            }
            if (randIndex >= 5 && randIndex <= 14)
            {
                Instantiate(EnemyTypes[1], transform.position, transform.rotation);
            }
            if (randIndex >= 15 && randIndex <= 24)
            {
                Instantiate(EnemyTypes[2], transform.position, transform.rotation);
            }
            if (randIndex >= 25 && randIndex <= 100)
            {
                Instantiate(EnemyTypes[3], transform.position, transform.rotation);
            }
        }
        if (waveFighter)
        {
            int randIndex = Random.Range(0, EnemyTypes.Length);

            Instantiate(EnemyTypes[randIndex], transform.position, transform.rotation);
        }
    }

   
    // if a burst, spawns an enemy, then counts it, spawns until the invoke repeating is canceled when the count reaches the number of enemies that was set to be spawned.
    //Then calls the invoke again, and waits the delay time.
    void SpawnBurst()
    {
        int randIndex = Random.Range(0, 100);

        if (randIndex >= 0 && randIndex <= 4)
        {
            Instantiate(EnemyTypes[0], transform.position, transform.rotation);
        }
        if (randIndex >= 5 && randIndex <= 14)
        {
            Instantiate(EnemyTypes[1], transform.position, transform.rotation);
        }
        if (randIndex >= 15 && randIndex <= 24)
        {
            Instantiate(EnemyTypes[2], transform.position, transform.rotation);
        }
        if (randIndex >= 25 && randIndex <= 100)
        {
            Instantiate(EnemyTypes[3], transform.position, transform.rotation);
        }
        enemySpawnNumber++;
            if (enemySpawnNumber == enemyBurstNumber)
        {
            CancelInvoke("SpawnBurst");
            InvokeRepeating("SpawnBurst", burstDelay, burstStagger);
            enemySpawnNumber = 0;
        }
    }
}
