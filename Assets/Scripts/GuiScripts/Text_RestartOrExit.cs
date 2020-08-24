using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_RestartOrExit : MonoBehaviour {

    private bool restart;
    private string rest;
    private bool exit;
    private string ex;

    private void Start()
    {
        rest = "Are you sure you want \n to RESTART the game?";
        ex = "Are you sure you want \n to LEAVE the game?";
    }

    void Update () {


        restart = GuiNumber.restart;
        exit = GuiNumber.exit;

        if (restart && !exit)
        {
            gameObject.GetComponent<Text>().text = rest;
        }
        else if (!restart && exit)
        {
            gameObject.GetComponent<Text>().text = ex;
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Error!!";
        }
    }
}
