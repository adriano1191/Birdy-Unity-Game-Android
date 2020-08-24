using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVideoButton : MonoBehaviour {

    public GameObject rewardAd;
	void Start () {
        rewardAd = GameObject.Find("RewardedVideo");
	}
	
    public void ShowReward()
    {
        rewardAd.GetComponent<RewardVideoAd>().ShowVideo();
    }
}
