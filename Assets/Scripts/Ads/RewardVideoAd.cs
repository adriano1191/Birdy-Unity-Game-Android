using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardVideoAd : MonoBehaviour {
    RewardBasedVideoAd rewardBasedVideo;
    public Sprite[] numberSprite;
    public bool showAd = false;
    public int buttonPhase = 0;
    private bool rewardedComplete;
    public GameObject rewButton;
    private Scene scene;
    private static RewardVideoAd adInstance;
    private float timer;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (adInstance == null)
        {
            adInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }

    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        timer += Time.deltaTime;
        if (scene.name == "Upgrade")
        {
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
            rewButton = GameObject.Find("Admob_add_Gold");
            if(rewButton != null)
            {

                if (buttonPhase == 0)
                {
                    rewButton.gameObject.GetComponent<Image>().sprite = numberSprite[0];
                }
                else if(buttonPhase == 1)
                {
                    rewButton.gameObject.GetComponent<Image>().sprite = numberSprite[1];
                }
                else if(buttonPhase == 2)
                {
                    rewButton.gameObject.GetComponent<Image>().sprite = numberSprite[2];
                }

            }
        }
        else
        {
            rewButton = null;
        }
        
    }



    private void Start()
    {

        rewardedComplete = false;

        if (rewardBasedVideo != null)
        {

            if (rewardBasedVideo.IsLoaded())
            {
            }

        }
        if(rewardBasedVideo == null)
        {

        }


        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        //DontDestroyOnLoad(gameObject);


        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        this.RequestRewardBasedVideo();
    }
    public void ShowVideo()
    {
        //RequestRewardBasedVideo();
        //////Log.mlog += "\n Try RequestRewardBasedVideo()";
        if (rewardBasedVideo.IsLoaded())
        {
            ////Log.mlog += "\n Reward Video Try Show";
            rewardBasedVideo.Show();
        }
        else
        {
            RequestRewardBasedVideo();
        }
    }

    private void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-7058312467069914/3575599078";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif

        //rewardBasedVideo = RewardBasedVideoAd.Instance;

        //AdRequest request = new AdRequest.Builder().Build();
        AdRequest request = new AdRequest.Builder()
.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
.AddTestDevice("BBA7E42FD33215B4F0C673FFE8D45994")  // My test device.
.Build();
        this.rewardBasedVideo.LoadAd(request, adUnitId);


        ////Log.mlog += "\n RequestRewardBasedVideo()";
    }




    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        ////Log.mlog += "\n Received";
        Phase(1);
        buttonPhase = 1;
        GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        ////Log.mlog += "\n Failed: " + args.Message;
        if(timer >= 1.0f)
        {

            RequestRewardBasedVideo();
            buttonPhase = 0;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
            timer = 0;

        }
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        ////Log.mlog += "\n Opened";
        GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
        buttonPhase = 0;
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        //Log.mlog += "\n Started";
        GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
        buttonPhase = 0;
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        //Log.mlog += "\n Closed";
        GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
        Phase(0);
        RequestRewardBasedVideo();
        buttonPhase = 0;
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
       // MonoBehaviour.print(String.Format("You just  got {0}  {1}!", args.Amount, args.Type));
        GetReward();

    }

    private void GetReward()
    {
        if (!rewardedComplete)
        {

            Stats.gold += 100;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
            //Debug.Log("User rewarded with: " + amount.ToString() + " " + type);
            ////Log.mlog += "\n Rewarded";
            Phase(0);
            buttonPhase = 2;
            //RequestRewardBasedVideo();

            //rewardedComplete = true;
        }
    }

    private void Phase(int phase)
    {
        buttonPhase = phase;
        ////Log.mlog += "\n Phase: " + phase;
    }



}
