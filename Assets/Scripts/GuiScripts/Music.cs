using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public void Music_Mute()
    {
        Debug.Log("Music_Mute");
        if (Stats.music_mute == 0)
        {
            Debug.Log("music_mute == 0");
            Stats.music_mute = 1;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().MusicSave();

        }
        else
        {
            Debug.Log("music_mute == 1");
            Stats.music_mute = 0;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().MusicSave();
        }
        Debug.Log(Stats.music_mute);
    }

    public void Sound_Mute()
    {
        Debug.Log("Sound_Mute");
        if (Stats.sound_mute == 0)
        {
            Debug.Log("Sound_mute == 0");
            Stats.sound_mute = 1;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().MusicSave();
        }
        else
        {
            Debug.Log("Sound_mute == 1");
            Stats.sound_mute = 0;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().MusicSave();
        }
    }
}
