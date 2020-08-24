using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AudioVol
{
    sound, music
}

public class Volume : MonoBehaviour {

    public AudioVol currAudio;
    public Slider sliderVolume;
    public GameObject statsObj;
    public float music_volume;
    public float sound_volume;
    private bool load = true;
    private int audioFirstTime;

    private void Start()
    {
        sliderVolume = GetComponent<Slider>();

        //music_volume = Stats.music_volume;
        //sound_volume = Stats.sound_volume;
        audioFirstTime = PlayerPrefs.GetInt("_audioFirstTime");
        if (audioFirstTime == 0)
        {
            music_volume = 1;
            sound_volume = 1;
        }
        else
        {
            music_volume = PlayerPrefs.GetFloat("music_volume");
            sound_volume = PlayerPrefs.GetFloat("sound_volume");
        }



    }

    private void Update()
    {
        if(currAudio == AudioVol.sound)
        {
            if (load)
            {
                sliderVolume.value = sound_volume;
                load = false;
            }
            sound_volume = sliderVolume.value;
            Stats.sound_volume = sound_volume;
        }
        else if(currAudio == AudioVol.music)
        {
            if (load)
            {
                sliderVolume.value = music_volume;
                load = false;
            }
            music_volume = sliderVolume.value;
            Stats.music_volume = music_volume;
        
        }

        statsObj.GetComponent<Stats>().MusicSave();

    }



}
