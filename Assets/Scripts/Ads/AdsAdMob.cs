using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdsAdMob : MonoBehaviour
{
    InterstitialAd interstitial;
    BannerView bannerView;
    string sceneName;
    public static bool boolAds;
    bool adShowed = false;
    private int numberLoadScene;
    private int limitLoadSceneAds;
    private int numberUpgrades;

    // Use this for initialization
    void Start()
    {
        //RequestBanner();
        RequestInterstitial();
       // bannerView.Hide();
        //StartGame();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Testowa")
        {
            numberLoadScene = PlayerPrefs.GetInt("numberLoadScene");
            numberLoadScene++;
            PlayerPrefs.SetInt("numberLoadScene", numberLoadScene);
            Debug.Log(numberLoadScene);
        }

        numberUpgrades = Stats.up_1 + Stats.up_2 + Stats.up_3 + Stats.up_4 + Stats.up_5;
        
        if(numberUpgrades < 15)
        {
            limitLoadSceneAds = 3;
        }
        else if(numberUpgrades >= 15 && numberUpgrades < 25)
        {
            limitLoadSceneAds = 2;
        }
        else if(numberUpgrades > 25)
        {
            limitLoadSceneAds = 1;
        }
        Debug.Log(numberUpgrades + " " + limitLoadSceneAds);



    }

    private void Update()
    {

        /* if (sceneName == "Testowa")
         {
             if (Shoot.showAd) //Po oddaniu strzalu 
             {

                 bannerView.Show();
                 Debug.Log("Show");
             }

         }
         else
         {
             bannerView.Hide();
             Debug.Log("Hide");
         }*/
    }
    private void RequestBanner()
    {
        string tag = "Banner";
#if UNITY_EDITOR
        string adUnitId = "unused";
        Debug.Log("Admob Unity Editor");
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-7058312467069914/4465288731";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.

        //test
        AdRequest request = new AdRequest.Builder()
    .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
    .AddTestDevice("BBA7E42FD33215B4F0C673FFE8D45994")  // My test device.
    .Build();
        //Release
        //AdRequest request = new AdRequest.Builder().Build();


        //bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        //bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        //bannerView.OnAdOpened += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        //bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;



        // Load the banner with the request.
        bannerView.LoadAd(request);
        
    }

    private void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
        Debug.Log("Admob Unity Editor");
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-7058312467069914/8081100118";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.

        //test
        AdRequest request = new AdRequest.Builder()
.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
.AddTestDevice("BBA7E42FD33215B4F0C673FFE8D45994")  // My test device.
.Build();

        //release
        //AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        //interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        //interstitial.OnAdOpened += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

    }
    public void ExitGame()
    {
        if (numberLoadScene >= limitLoadSceneAds)
        {
            numberLoadScene = 0;
            PlayerPrefs.SetInt("numberLoadScene", numberLoadScene);
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
                //interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                //Log.mlog += ("\nThe interstitial was loaded.");
                adShowed = true;
            }
            else
            {
                //interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                //Log.mlog += ("\nThe interstitial wasn't loaded yet.");
                //SceneManager.LoadScene("Upgrade");
            }
        }
    }
    public void StartGame()
    {
        if(numberLoadScene >= limitLoadSceneAds)
        {
            numberLoadScene = 0;
            PlayerPrefs.SetInt("numberLoadScene", numberLoadScene);
            if (!adShowed)
            {

                if (interstitial.IsLoaded())
                {
                        interstitial.Show();
                        //interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                        //Log.mlog += ("\nThe interstitial was loaded.");
                        adShowed = true;         
                }
                else
                {
                    //interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                    //Log.mlog += ("\nThe interstitial wasn't loaded yet.");
                    //SceneManager.LoadScene("Upgrade");
                }
            }
        }
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("OnAdLoaded event received.");
        //Log.mlog += "\n OnAdLoaded event Received.";
        // Handle the ad loaded event.
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("OnAdFailedToLoad event received.");
        //Log.mlog += "\n OnAdFailedToLoad event received." + args.Message;
        RequestInterstitial();
        // Handle the ad failed to load.
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        Debug.Log("OnAdOpened event received.");
        //Log.mlog += "\n OnAdOpened event received.";
        // Handle the ad ad is clicked.
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("OnAdClosed event received.");
        //Log.mlog += "\n OnAdClosed event received.";
        //SceneManager.LoadScene("Upgrade");
        // Handle the user returned from the app after an ad click.
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("OnAdLeavingApplication event received.");
        //Log.mlog += "\n OnAdLeavingApplication event received.";
        // Handle the ad click caused the user to leave the application.
    }

    public void showBanner()
    {
        bannerView.Show();
        Debug.Log("Show Ads");
    }
    public void hideBanner()
    {
        bannerView.Hide();
        Debug.Log("Hide Ads");
    }
}
