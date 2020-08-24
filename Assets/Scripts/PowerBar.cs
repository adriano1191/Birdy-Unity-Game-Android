using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public float speedMax;
    public float speed;
    public float barSize;
    GameObject power;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        EnergyChange();
        if (Stats.shooted)
        {
            gameObject.SetActive(false);
             
        }


    }

    void EnergyChange()
    {
        GameObject sStats = GameObject.Find("Stats");
        float speedMax_Upgrade = sStats.gameObject.GetComponent<Up_4>().shoot_speed_upgrade;
        power = gameObject.transform.GetChild(0).gameObject;
        speedMax = Stats.speedMax + speedMax_Upgrade;
        speed = Stats.speed;
        barSize = (speed / speedMax) * 1.0f;

        power.GetComponent<Image>().fillAmount = barSize;
        
        
        
    }
}
