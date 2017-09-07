using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{

    public Camera MainCamera;
    public GameObject MouseFollowObj;
    public GameObject ItemTransparent;
    public Vector3 mousePosition;
    public GameObject TestFloorObject;
    public GameObject TestWallObject;
    public GameObject WallObjectPos;
    bool inFloorPlacement;
    bool inWallPlacement;

    int RotationAngle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("hitting 1");
            inFloorPlacement = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("hitting 2");
            inWallPlacement = true;
        }
        if (inFloorPlacement)
        {
            MouseFollowObj.SetActive(true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //MouseFollowObj.transform.position = new Vector3(mousePosition.x, 1, mousePosition.z);

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(mousePosition.x, 1, mousePosition.z), -Vector3.up, out hit))
            {
                if (hit.collider != null && hit.collider.tag == "floor")
                {
                    MouseFollowObj.transform.position = new Vector3(Mathf.Floor(mousePosition.x) + .5f, 1, Mathf.Floor(mousePosition.z) + .5f);
                }
                else
                {
                    print("not hitting floor");
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(TestFloorObject, new Vector3(MouseFollowObj.transform.position.x, 0, MouseFollowObj.transform.position.z), MouseFollowObj.transform.rotation);
            }
            else if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                MouseFollowObj.SetActive(false);
                inFloorPlacement = false;
            }
        }
        if(inWallPlacement)
        {
            MouseFollowObj.SetActive(true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //MouseFollowObj.transform.position = new Vector3(mousePosition.x, 1, mousePosition.z);

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(mousePosition.x, 1, mousePosition.z), -Vector3.up, out hit))
            {
                if (hit.collider != null && hit.collider.tag == "floor")
                {
                    MouseFollowObj.transform.position = new Vector3(Mathf.Floor(mousePosition.x), 1, Mathf.Floor(mousePosition.z));
                }
                else
                {
                    print("not hitting floor");
                }
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                RotationAngle += 90;
                if(RotationAngle >= 360)
                { RotationAngle = 0;
                }
               MouseFollowObj.transform.eulerAngles = Vector3.up * RotationAngle;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(TestWallObject, new Vector3(WallObjectPos.transform.position.x, 0, WallObjectPos.transform.position.z), MouseFollowObj.transform.rotation);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                MouseFollowObj.SetActive(false);
                inWallPlacement = false;
            }
        }
    
    }
}

