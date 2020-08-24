using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_4 : MonoBehaviour {

    public float shoot_speed_upgrade;
    public float shoot_rate_speed_upgrade;

    private void Start()
    {
        Upgrade_4();
    }

    public void Upgrade_4()  //siła oraz szybkość wystrzału z działa
    {
        float number_upgrade;

        number_upgrade = Stats.up_4;
        shoot_speed_upgrade = (0.08f * number_upgrade) * 15;
        shoot_rate_speed_upgrade = (0.3f * number_upgrade) * 20;
       /* if(number_upgrade <= 6)
        {
            shoot_speed_upgrade = (0.1f * number_upgrade) * 20;
            shoot_rate_speed_upgrade = (0.1f * number_upgrade) * 20;
        }
        else if(number_upgrade > 6 && number_upgrade <= 12)
        {
            shoot_speed_upgrade = (0.1f * number_upgrade) * 20;
            shoot_rate_speed_upgrade = (0.1f * number_upgrade) * 20;
        }
        else if (number_upgrade > 12 && number_upgrade <= 18)
        {
            shoot_speed_upgrade = (0.1f * number_upgrade) * 20;
            shoot_rate_speed_upgrade = (0.1f * number_upgrade) * 20;
        }
        else if (number_upgrade > 18 && number_upgrade <= 24)
        {
            shoot_speed_upgrade = (0.1f * number_upgrade) * 20;
            shoot_rate_speed_upgrade = (0.1f * number_upgrade) * 20;
        }*/
    }
}
