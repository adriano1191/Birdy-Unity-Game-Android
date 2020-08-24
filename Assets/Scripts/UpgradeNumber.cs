using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Upgrade
{
    up_1, up_2, up_3, up_4, up_5
}

public class UpgradeNumber : MonoBehaviour {

    public GameObject[] upGraphic;
    public Sprite[] upSprites;
    public int upgradeNumber;
    public Upgrade currUpgrade;
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            upGraphic[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (currUpgrade == Upgrade.up_1)
        {
            upgradeNumber = Stats.up_1;
        }
        else if (currUpgrade == Upgrade.up_2)
        {
            upgradeNumber = Stats.up_2;
        }
        else if (currUpgrade == Upgrade.up_3)
        {
            upgradeNumber = Stats.up_3;
        }
        else if (currUpgrade == Upgrade.up_4)
        {
            upgradeNumber = Stats.up_4;
        }
        else if (currUpgrade == Upgrade.up_5)
        {
            upgradeNumber = Stats.up_5;
        }

        UpgradeNumberVisible();
    }


    private void UpgradeNumberVisible()
    {
        if(upgradeNumber <= 6)
        {
            for(int i = 0; i < upgradeNumber; i++)
            {
                upGraphic[i].gameObject.GetComponentInChildren<Image>().sprite = upSprites[0];
                upGraphic[i].gameObject.SetActive(true);
            }
        }
        else if(upgradeNumber > 6 && upgradeNumber <= 12)
        {
            for (int i = 0; i < upgradeNumber - 6; i++)
            {
                upGraphic[i].gameObject.GetComponentInChildren<Image>().sprite = upSprites[1];
                upGraphic[i].gameObject.SetActive(true);
            }
        }
        else if (upgradeNumber > 12 && upgradeNumber <= 18)
        {
            for (int i = 0; i < upgradeNumber - 12; i++)
            {
                upGraphic[i].gameObject.GetComponentInChildren<Image>().sprite = upSprites[2];
                upGraphic[i].gameObject.SetActive(true);
            }
        }
        else if (upgradeNumber > 18 && upgradeNumber <= 24)
        {
            for (int i = 0; i < upgradeNumber - 18; i++)
            {
                upGraphic[i].gameObject.GetComponentInChildren<Image>().sprite = upSprites[3];
                upGraphic[i].gameObject.SetActive(true);
            }
        }
    }
}
