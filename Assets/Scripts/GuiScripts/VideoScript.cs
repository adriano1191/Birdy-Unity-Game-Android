using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour {

    public VideoPlayer Intro_Movie;
    private bool isPlay = false;
    private bool itseditor = false;

    void Start()
    {
        Intro_Movie.Play();
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        itseditor = true;
#else
        Debug.Log("No Unity Editor");
        itseditor = false;
#endif
    }
    private void Update()
    {
        if (Intro_Movie.isPlaying)
        {
            isPlay = transform;
        }
        else if (isPlay)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (itseditor)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (!itseditor)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

}
