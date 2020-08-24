using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioSrc
{
    sound, music
}
public class SoundsPlayMute : MonoBehaviour {

    private AudioSource audio;
    public AudioSrc currAudio;
    private int mute;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {


        if (currAudio == AudioSrc.sound)
        {
            mute = Stats.sound_mute;
            audio.volume = Stats.sound_volume;
        }
        else
        {
            mute = Stats.music_mute;
            audio.volume = Stats.music_volume;
        }
        Mute();

    }

    private void Mute()
    {
        if(mute == 0)
        {
            audio.mute = false;
        }
        else
        {
            audio.mute = true;
        }
    }

}
