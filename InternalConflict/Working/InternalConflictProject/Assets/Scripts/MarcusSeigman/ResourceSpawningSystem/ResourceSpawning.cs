using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawning : MonoBehaviour
{

    public GameObject[] resources;
    public int numberOfResourceToSpawn;
    public int minXvalue;
    public int maxXValue;
    public int minZValue;
    public int maxZValue;
    int l = 0;


    // Use this for initialization
    void Start()
    {
        spawnResources();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void spawnResources()
    {
        int i = Random.Range(minXvalue, maxXValue);
        int k = Random.Range(minZValue, maxZValue);
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x + i + .5f, 5, transform.position.x + k + .5f), -Vector3.up);

        while (l < numberOfResourceToSpawn)
        {
            if (Physics.Raycast(new Vector3(i, 5, k), -Vector3.up, out hit))
            {
                if (hit.collider != null && hit.collider.tag == "floor")
                {
                    int j = Random.Range(0, resources.Length);
                    Instantiate(resources[j], new Vector3(transform.position.x + i + .5f, 0f, transform.position.z + k + .5f), Quaternion.identity);
                    l++;
                    spawnResources();
                }
                else
                {
                    print("not hitting floor");
                    spawnResources();
                }
            }
        }
    }
}
