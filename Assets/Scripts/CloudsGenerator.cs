using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsGenerator : MonoBehaviour {

    public GameObject cloud;
    private float y = 10;
    private int count = 24;
    private float r;
    private int sw = 1;
    private Vector2 spawnVec;

    private void Start()
    {
        Spawnclouds();
    }

    private void Spawnclouds()
    {



        for (int i = 0; i < count; i++)
        {

            for (int j = 0; j <= 3; j++)
            {
                r = Random.Range(-2, 2);
                switch (sw)
            {
                    case 1:
                        spawnVec = new Vector2(transform.position.x + 0 + r, transform.position.y + (y * (i + 1)) + r);
                        sw = 2;
                        break;
                    case 2:
                        spawnVec = new Vector2(transform.position.x + 5 + r, transform.position.y + (y * (i + 1)) + r);
                        sw = 3;
                        break;
                    case 3:
                        spawnVec = new Vector2(transform.position.x + 10 + r, transform.position.y + (y * (i + 1)) + r);
                        sw = 1;
                        break;
            }

            

                    GameObject cloudClone = Instantiate(cloud, spawnVec, Quaternion.identity) as GameObject;
                    cloudClone.transform.parent = gameObject.transform;
                    //cloudClone.transform.position = new Vector3(transform.position.x, transform.position.y, 14f);

            }

        }
    }
}
