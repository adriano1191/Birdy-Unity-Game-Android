using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuy : MonoBehaviour {

    public void BuyUpgrade_1()
    {
        if(Stats.up_1 < 24 && Stats.gold >= Stats.up_1_cost)
        {
            Stats.up_1++;
            Stats.gold -= Stats.up_1_cost;           
        }
    }
    public void BuyUpgrade_2()
    {
        if (Stats.up_2 < 24 && Stats.gold >= Stats.up_2_cost)
        {
            Stats.up_2++;
            Stats.gold -= Stats.up_2_cost;
        }
    }
    public void BuyUpgrade_3()
    {
        if (Stats.up_3 < 24 && Stats.gold >= Stats.up_3_cost)
        {
            Stats.up_3++;
            Stats.gold -= Stats.up_3_cost;
        }
    }
    public void BuyUpgrade_4()
    {
        if (Stats.up_4 < 24 && Stats.gold >= Stats.up_4_cost)
        {
            Stats.up_4++;
            Stats.gold -= Stats.up_4_cost;
        }
    }
    public void BuyUpgrade_5()
    {
        if (Stats.up_5 < 24 && Stats.gold >= Stats.up_5_cost)
        {
            Stats.up_5++;
            Stats.gold -= Stats.up_5_cost;
        }
    }
}
