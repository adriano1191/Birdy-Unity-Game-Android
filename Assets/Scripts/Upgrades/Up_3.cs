using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_3 : MonoBehaviour {

    public float fly_speed_upgrade;

    private void Start()
    {
        Upgrade_3();
    }

    public void Upgrade_3()  //przyspieszenie w prawo podczas skoku
    {
        float number_upgrade;

        number_upgrade = Stats.up_3;
        fly_speed_upgrade = (0.2f * number_upgrade) * 100;
    }
}
