using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public AudioClip mainMenuAudio;
    public AudioClip gameAudio;
    private int clipId;
    private AudioSource audiosrc;
    private static MusicPlayer musicInstance;



    void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }

    }

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        PlayMusic(mainMenuAudio);
        clipId = 1;

    }


    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {

            PlayMusic(gameAudio);
            clipId = 0;
        }
        else
        {
            if (clipId != 1)
            {
                PlayMusic(mainMenuAudio);
                clipId = 1;
            }
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        
        audiosrc.clip = clip;
        audiosrc.Play();
    }
}
