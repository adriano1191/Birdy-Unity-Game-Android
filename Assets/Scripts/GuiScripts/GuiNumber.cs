using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiNumber : MonoBehaviour {

    public GameObject PlayGui;
    public GameObject PauseGui;
    public GameObject CommuniqueGui;
    public GameObject CanvasEndGameGui;
    public GameObject ButtonJump;
    public GameObject RecordText;
    public static int gui;
    public static bool exit;
    public static bool restart;
    public int test;
	void Start () {
        gui = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //gui = test;
        if (Stats.shooted)
        {
            ButtonJump.SetActive(true);
        }
        if (GuiNumber.gui == 0)
        {
            Time.timeScale = 1;
            PlayGui.SetActive(true);
            PauseGui.SetActive(false);
            CommuniqueGui.SetActive(false);
            CanvasEndGameGui.SetActive(false);
        }
        else if(GuiNumber.gui == 1)
        {
            Time.timeScale = 0;
            PlayGui.SetActive(false);
            PauseGui.SetActive(true);
            CommuniqueGui.SetActive(false);
            CanvasEndGameGui.SetActive(false);
            
        }
        else if (GuiNumber.gui == 2)
        {
            Time.timeScale = 0;
            PlayGui.SetActive(false);
            PauseGui.SetActive(false);
            CommuniqueGui.SetActive(true);
            CanvasEndGameGui.SetActive(false);

        }
        else if (GuiNumber.gui == 3)
        {
            RecordText.GetComponent<Record>().NewRecord(Stats.current_distance_x);
            Time.timeScale = 0;
            PlayGui.SetActive(false);
            PauseGui.SetActive(false);
            CommuniqueGui.SetActive(false);
            CanvasEndGameGui.SetActive(true);
            GameObject.Find("Stats").gameObject.GetComponent<AdsAdMob>().StartGame();
        }

    }
}
