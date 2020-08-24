using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public GameObject coin;
    public Vector2 coinLocation;
    private float x_pos;
    private float y_pos;
    private float x_rand;
    private float y_rand;
    private int maxCoin;
    private bool spawn = false;
    private float curDist;
    private float lastDist = 0;
    private float curPosY = 0;
    private float lastPosY = 0;
    private bool fly = true;
    private float camY = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Dist();
        x_pos = Camera.main.transform.position.x;
        y_pos = Camera.main.transform.position.y;



        //if (timeRand <= 0 && y_pos > 0)
        if(spawn)
        {
            maxCoin = Random.Range(1, 5);
            x_rand = Random.Range(8.0f, 15.0f);
            y_rand = Random.Range(-6.0f, 6.0f);

            if (y_pos + y_rand <= 0)
            {
                y_pos = 1;
                y_rand = 1;
            }

            for (int i = 0; i < maxCoin; i++)
            {
                coinLocation = new Vector2(x_pos + x_rand + (i * 0.7f), y_pos + y_rand);
                GameObject coinClone = Instantiate(coin, coinLocation, Quaternion.identity) as GameObject;
                coinClone.transform.parent = gameObject.transform;
            }


            spawn = false;
        }
    }

    void Dist()
    {
        /* //Liczy dystans po wektorze
        Vector2 start;
        Vector2 cameraVec;


        cameraVec = Camera.main.transform.position;
        start = new Vector2(0, 0);
        curDist = Vector2.Distance(start, cameraVec);
        Debug.Log(curDist);
        if(curDist >= lastDist + 5)
        {

            spawn = true;
            lastDist = curDist;

            //Debug.Log("LastDist: " + lastDist + " CurDist: " + curDist);
        }
        */
        Vector2 start;
        Vector2 cameraVec;
        

        curPosY = Camera.main.transform.position.y;
        if (curPosY < lastPosY && fly)
        {
            //obiekt spada

            camY = curPosY * 2;
           // Debug.Log("Spadam");
            fly = false;
            cameraVec = Camera.main.transform.position;
            start = new Vector2(0, camY);
            curDist = Vector2.Distance(start, cameraVec);
            lastDist = curDist;

        }
        else if (curPosY > lastPosY && !fly)
        {
            //Debug.Log("LECE");
            lastDist = curDist;
            camY = 0;
            fly = true;
            cameraVec = Camera.main.transform.position;
            start = new Vector2(0, camY);
            curDist = Vector2.Distance(start, cameraVec);
            lastDist = curDist;
        }

        lastPosY = curPosY;
        cameraVec = Camera.main.transform.position;
        start = new Vector2(0, camY);
        curDist = Vector2.Distance(start, cameraVec);



        if (curDist >= lastDist + 5)
        {
            Debug.Log("Spawn");
            spawn = true;
            lastDist = curDist;

            //Debug.Log("LastDist: " + lastDist + " CurDist: " + curDist);
        }
        //Debug.Log("LastDist: " + lastDist + " CurDist: " + curDist);
        //Debug.Log(curDist);
    }


}
