using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_2 : MonoBehaviour {

    public float jump_speed_upgrade;

    private void Start()
    {
        Upgrade_2();
    }

    public void Upgrade_2()  //siła skoków
    {
        float number_upgrade;

        number_upgrade = Stats.up_2;
        jump_speed_upgrade = (0.05f * number_upgrade) * 100;
    }
}
