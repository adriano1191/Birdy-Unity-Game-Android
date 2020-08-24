using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {
    //Muzyka
    private int audioFirstTime = 0;
    public static int music_mute;
    public static int sound_mute;
    public static float music_volume = 1.0f;
    public static float sound_volume = 1.0f;

    //gold, earned_gold, current_distance, max_distance
    public static int gold = 0;
    public static int earned_gold;
    public static int current_distance;
    public static int current_distance_x;
    private float dist;
    private float dist_x;
    public static int max_distance;
    public static int energyMax;
    public static int energy;
    public static float speed;
    public static float speedMax = 20f;
    public static float speedRate = 25f;
    public static bool shooted = false;

    //Ile razy zostalo zakupione dane ulepszenie
    public static int up_1;
    public static int up_2;
    public static int up_3;
    public static int up_4;
    public static int up_5 = 0;

    public static int up_1_cost;
    public static int up_2_cost;
    public static int up_3_cost;
    public static int up_4_cost;
    public static int up_5_cost;


    void Start () {
        //gold = 0;
        //energyMax = 20;
        Debug.Log("LoadData");
        //music_volume = 1f;
        //sound_volume = 1f;
        music_mute = PlayerPrefs.GetInt("music_mute");
        sound_mute = PlayerPrefs.GetInt("sound_mute");

        audioFirstTime = PlayerPrefs.GetInt("_audioFirstTime");
        Debug.Log("Muzyka : " + audioFirstTime);
        if(audioFirstTime == 0)
        {
            music_volume = 1.0f;
            sound_volume = 1.0f;
            Debug.Log("Muzyka Działa");
            MusicSave();
            PlayerPrefs.SetInt("_audioFirstTime", 1);

        }
        else
        {
            music_volume = PlayerPrefs.GetFloat("music_volume");
            sound_volume = PlayerPrefs.GetFloat("sound_volume");
        }

        earned_gold = 0;
        gold = PlayerPrefs.GetInt("gold");
        max_distance = PlayerPrefs.GetInt("max_distance");
        up_1 = PlayerPrefs.GetInt("up_1");
        up_2 = PlayerPrefs.GetInt("up_2");
        up_3 = PlayerPrefs.GetInt("up_3");
        up_4 = PlayerPrefs.GetInt("up_4");
        //up_1 = 24;
        //up_2 = 24;
        //up_3 = 24;
        //up_4 = 24;

        if (up_1 <= 0) up_1 = 1;
        if (up_2 <= 0) up_2 = 1;
        if (up_3 <= 0) up_3 = 1;
        if (up_4 <= 0) up_4 = 1;
        if (up_5 <= 0) up_5 = 1;

        gameObject.GetComponent<Up_1>().Upgrade_1();
        gameObject.GetComponent<Up_2>().Upgrade_2();
        gameObject.GetComponent<Up_3>().Upgrade_3();
        gameObject.GetComponent<Up_4>().Upgrade_4();
        energyMax = 5 + gameObject.GetComponent<Up_1>().energy_upgrade;
        energy = energyMax;
        


        speed = 1f;
        shooted = false;

    }
	
	// Update is called once per frame
	void Update () {

        dist = Vector2.Distance(new Vector2(0f, 0f), new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)) ;
        current_distance = (int) dist;

        dist_x = Camera.main.transform.position.x;
        current_distance_x = (int)dist_x;

        if(GuiNumber.gui == 3)
        {
            SaveDate();
            //earned_gold = 0;
        }
        //gold = gold + earned_gold;

        /* 
        Debug.Log("Gold: " + gold);
        Debug.Log("energyMax: "+ energyMax);
        Debug.Log("energy: " + energy);
        */
    }

    public void SaveDate()
    {
        PlayerPrefs.SetInt("gold", gold + earned_gold);
        PlayerPrefs.SetInt("max_distance", max_distance);
        PlayerPrefs.SetInt("up_1", up_1);
        PlayerPrefs.SetInt("up_2", up_2);
        PlayerPrefs.SetInt("up_3", up_3);
        PlayerPrefs.SetInt("up_4", up_4);

        //Debug.Log(SceneManager.GetActiveScene() + " " + gold + " + " + earned_gold);

        
    }

    public void MusicSave()
    {
        PlayerPrefs.SetInt("music_mute", music_mute);
        PlayerPrefs.SetInt("sound_mute", sound_mute);
        PlayerPrefs.SetFloat("music_volume", music_volume);
        PlayerPrefs.SetFloat("sound_volume", sound_volume);


}
}
