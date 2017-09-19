using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public Vector3 mousePosition;

    
    public float speed;

    public bool isAttacking;
    public GameObject AttackPivot;
    public GameObject SwordObject;

    public GameObject Bullet;
    public GameObject BulletSpawnPoint;
        // Use this for initialization
        void Start () {
        myRigidbody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(Bullet, BulletSpawnPoint.transform.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if(!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Rotate(AttackPivot, Vector3.up, -130, .2f));
            }
        }
        // moveInput.x = Input.GetAxis("Horizontal");
        //moveInput.z = Input.GetAxis("Vertical");
       // moveVelocity = moveInput * moveSpeed;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 targetDir = new Vector3(mousePosition.x, transform.position.y, mousePosition.z) - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
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
