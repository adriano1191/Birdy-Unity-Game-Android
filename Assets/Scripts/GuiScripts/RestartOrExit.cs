using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrExit : MonoBehaviour {

    private bool restart;
    private bool exit;

    // Update is called once per frame
    void Update () {

	}

    public void Restart()
    {
        GuiNumber.restart = true;
        GuiNumber.exit = false;


    }

    public void Exit()
    {
        GuiNumber.exit = true;
        GuiNumber.restart = false;

    }

    public void ButtonRestart_OR_Exit()
    {
        restart = GuiNumber.restart;
        exit = GuiNumber.exit;

        if (restart && !exit)
        {
            SceneManager.LoadScene("Testowa");
        }
        else if (!restart && exit)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");

            Debug.Log("EXIT DO MENU!!!");
        }
        else
        {
            Debug.Log("RESTART OR EXIT SCRIPT ERROR");
        }

        
    }


}
