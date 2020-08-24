using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject birdPrefab;
    public Transform spawner;
    public Transform cannon;
    public Vector2 shootLocation;
    public float speed;
    public float speedMax;
    public float speedRate;
    private bool speedIncreases = true;
    GameObject sStats;
    float speedMax_Upgrade;
    float speedRate_Upgrade;

    private void Update()
    {
        
    }

    public void LoadingShoot()
    {
        sStats = GameObject.Find("Stats");
         speedMax_Upgrade = sStats.gameObject.GetComponent<Up_4>().shoot_speed_upgrade;
         speedRate_Upgrade = sStats.gameObject.GetComponent<Up_4>().shoot_rate_speed_upgrade;
        if (Stats.speed <= (Stats.speedMax + speedMax_Upgrade) && speedIncreases)
        {

            Stats.speed += (Stats.speedRate + speedRate_Upgrade) * Time.deltaTime;
            if (Stats.speed >= (Stats.speedMax + speedMax_Upgrade))
            {
                Stats.speed = Stats.speedMax + speedMax_Upgrade;
                speedIncreases = false;
            }
        }
        else if (!speedIncreases)
        {

            Stats.speed -= (Stats.speedRate + speedRate_Upgrade) * Time.deltaTime;
            if (Stats.speed <= 2)
            {
                Stats.speed = 2;
                speedIncreases = true;
            }
        }
    }

    public void Fire()
    {

        AdsAdMob.boolAds = true;
        speed = Stats.speed;
        speedMax = Stats.speedMax + speedMax_Upgrade;
        speedRate = Stats.speedRate + speedRate_Upgrade;
        Stats.shooted = true;
        shootLocation = new Vector3(spawner.transform.position.x, spawner.transform.position.y, -5);
        GameObject clone = Instantiate(birdPrefab, shootLocation, Quaternion.identity) as GameObject;
        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        clonerb.AddRelativeForce(cannon.TransformDirection(new Vector2((Mathf.Cos(cannon.rotation.z * Mathf.Deg2Rad) * speed),
                                                                             (Mathf.Sin(cannon.rotation.z * Mathf.Deg2Rad) * speed))),
                                                                             ForceMode2D.Impulse);

        
    }

}
