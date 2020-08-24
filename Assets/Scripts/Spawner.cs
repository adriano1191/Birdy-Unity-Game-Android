using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnObj;
    private Vector2 spawnLocation;
    public int maxSpawn;
    public float spawnSpace = 0.7f;
    private float x_SpawnPos;
    private float y_SpawnPos;
    private bool spawn = false;
    private float x_rand;
    private float y_rand;
    private float x_pos;
    private float y_pos;

    //FLY()
    private bool fly = false;
    private float lastPosY;
    private float start_fix_y;
    //DIST()
    private float distance;
    private float lastDist = 0;
    public float spawnDistance = 5;

    //odstepy
    public float y_max = 470; //470 to max
    public float y_minimal = 3;
    public float x_pos_add_distance = 0;
    public float y_pos_add_distance = 0;

    void Start()
    {
        lastPosY = Camera.main.transform.position.y;
    }

    void Update()
    {
        Fly();
        Dist();
    }
    void SpawnerObj()
    {
        if (y_pos + y_rand <= y_minimal)
        {
            y_pos += y_minimal;
            y_rand = Mathf.Abs(y_rand);
        }else if(y_pos + y_rand >= y_max)
        {
            y_pos = y_max;
            y_rand = Mathf.Abs(y_rand);
        }
        int howManySpaw = Random.Range(1, maxSpawn);
        for (int i = 0; i < howManySpaw; i++)
        {
            spawnLocation = new Vector2(x_pos + x_rand + (i * spawnSpace), y_pos + y_rand);
            GameObject spawnedObj = Instantiate(spawnObj, spawnLocation, Quaternion.identity) as GameObject;
            spawnedObj.transform.parent = gameObject.transform;
        }
    }

    void Spawn()
    {

        if (spawn)
        {
             x_pos = Camera.main.transform.position.x;
             y_pos = Camera.main.transform.position.y;




                 x_rand = Random.Range(8.0f, 11.0f) + x_pos_add_distance;
                 y_rand = Random.Range(-3.0f, 3.0f) + y_pos_add_distance;
                 SpawnerObj();
                if (fly)
                {
                    x_rand = Random.Range(-3.0f, 15.0f) + x_pos_add_distance;
                    y_rand = Random.Range(7.6f, 10.0f) + y_pos_add_distance;
                    SpawnerObj();

                }
                else if(!fly)
                {
                    x_rand = Random.Range(-3.0f, 15.0f) + x_pos_add_distance;
                    y_rand = Random.Range(-6.8f, -10.0f) - y_pos_add_distance;
                    SpawnerObj();
                }

            




           /* 
            for (int i = 0; i < howManySpaw; i++)
            {
                spawnLocation = new Vector2(x_pos + x_rand + (i * 0.7f), y_pos + y_rand);
                Debug.Log(spawnLocation);
                GameObject spawnedObj = Instantiate(spawnObj, spawnLocation, Quaternion.identity) as GameObject;
                spawnedObj.transform.parent = gameObject.transform;
            }
            */

            spawn = false;
        }
    }

    void Dist()
    {
        Vector2 start;
        Vector2 cameraPos;
 
        start = new Vector2(0, start_fix_y);
        cameraPos = Camera.main.transform.position;

        distance = Vector2.Distance(start, cameraPos);
        //Debug.Log(distance);
        if (distance >= lastDist + spawnDistance)
        {
            //Debug.Log("Spawn");
            spawn = true;
            lastDist = distance;
            Spawn();
        }
    }

    void Fly()
    {
        if (Camera.main.transform.position.y < lastPosY && fly)
        {
            //Bird Spada
            start_fix_y = Camera.main.transform.position.y * 2.0f;
            Dist();
            lastDist = distance;
            fly = false;
            //Debug.Log("Spada");
        }
        else if (Camera.main.transform.position.y > lastPosY && !fly)
        {
            //Bird Leci
            start_fix_y = 0;
            Dist();
            lastDist = distance;
            fly = true;
            //Debug.Log("Leci");
        }
        lastPosY = Camera.main.transform.position.y;
    }




}
