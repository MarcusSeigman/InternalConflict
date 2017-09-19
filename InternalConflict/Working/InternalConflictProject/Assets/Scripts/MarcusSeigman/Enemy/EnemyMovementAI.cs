using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovementAI : MonoBehaviour
{
    public GameObject TargetObject;
    public GameObject HeartObject;
    public GameObject PlayerObject;
    public float TurnSpeed;
    public Vector3 PlayerDirection;
    public float PlayerAngle;
    public float PlayerDistance;
    public float moveSpeed;

    public bool isAttacking;
    public GameObject AttackPivot;
    public GameObject SwordObject;

    public GameObject Bullet;
    public GameObject BulletSpawnPoint;
    //sets the initial pos, and if it is a burst spawner, starts the spawn count down.

    void Awake()
    {
        HeartObject = GameObject.Find("Heart");
        PlayerObject = GameObject.Find("PlayerPlaceholder");
        TargetObject = HeartObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            moveSpeed = 0;
        }
        else moveSpeed = .01f;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.Translate(Vector3.forward * moveSpeed);
        Vector3 targetDir = new Vector3(TargetObject.transform.position.x, transform.position.y, TargetObject.transform.position.z) - transform.position;
        float step = TurnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
        PlayerDirection = transform.position - PlayerObject.transform.position;
        PlayerAngle = Vector3.Angle(PlayerDirection, transform.forward);
        PlayerDistance = PlayerDirection.magnitude;
        if (PlayerAngle > 90 && PlayerDistance < 2)
        {
            TargetObject = PlayerObject;
        }
        else
        {
            TargetObject = HeartObject;
        }

        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" || other.tag == "WallItem" || other.tag == "Heart" || other.tag == "Resource")
        {
            print(other.tag);
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Rotate(AttackPivot, Vector3.up, -130, .2f));
            }
        }
    }

    IEnumerator Rotate(GameObject PivPoint, Vector3 axis, float angle, float duration = 1.0f)
    {
        SwordObject.SetActive(true);
        Quaternion from = PivPoint.transform.localRotation;
        Quaternion to = PivPoint.transform.localRotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            PivPoint.transform.localRotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        PivPoint.transform.localRotation = to;
        isAttacking = false;
        SwordObject.SetActive(false);
        PivPoint.transform.localRotation = from;

    }

}
