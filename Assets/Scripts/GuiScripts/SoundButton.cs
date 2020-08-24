using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {
    public Sprite button_0;
    public Sprite button_1;
    private void Awake()
    {
        //Debug.Log("button awake");
        Stats.sound_mute = PlayerPrefs.GetInt("sound_mute");
        ChangeButton_Sound();
    }

    public void ChangeButton_Sound()
    {
        if (Stats.sound_mute == 0)
        {
            //Debug.Log("sound unmute");
            gameObject.GetComponentInChildren<Image>().sprite = button_0;
        }
        else
        {
            //Debug.Log("sound mute");
            gameObject.GetComponentInChildren<Image>().sprite = button_1;
        }
    }
}
