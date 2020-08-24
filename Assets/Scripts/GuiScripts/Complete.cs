using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour {

    void CompleteMap()
    {
        PlayerPrefs.SetInt("gold",Stats.gold + Stats.earned_gold);
    }
}
