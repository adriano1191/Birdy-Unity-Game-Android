using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGUI : MonoBehaviour {

    private bool click = false;
    private bool click_two = false;
    public GameObject Panel;
    public GameObject Options;
    public GameObject Credits;
    float time = 0f;
    public void Button_Start()
    {
        time = 0f;
        click = true;
        click_two = true;
        SceneManager.LoadScene("Upgrade");

    }

    public void Button_Options()
    {
        Panel.SetActive(false);
        Options.SetActive(true);
    }

    public void Button_Credits()
    {
        Panel.SetActive(false);
        Credits.SetActive(true);
    }

    public void Button_Exit()
    {
        Application.Quit();
    }

    public void Button_Back()
    {
        Panel.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    private void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        //lscene();
    }

    private void lscene()
    {
        //reklama przy starcie
        /*if (time > 0.5f && click)
        {
            GameObject menu = GameObject.Find("MainMenu");
            menu.GetComponent<AdsAdMob>().StartGame();
            click = false;

        }

        if (time > 1f && click_two)
        {
            time = 0;

            SceneManager.LoadScene("Upgrade");
            click_two = false;

        }*/
        
    }
}
