using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour {

    public Sprite button_0;
    public Sprite button_1;

    private void Awake()
    {
        //Debug.Log("button awake");
        Stats.music_mute = PlayerPrefs.GetInt("music_mute");

        ChangeButton_Music();

    }

    public void ChangeButton_Music()
    {
        //Debug.Log("button change music");
        if (Stats.music_mute == 0)
        {
            //Debug.Log("music unmute ");
            gameObject.GetComponentInChildren<Image>().sprite = button_0;
        }
        else
        {
            //Debug.Log("music mute");
            gameObject.GetComponentInChildren<Image>().sprite = button_1;
        }
    }

}
