using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd : MonoBehaviour {

    public void End()
    {

        SceneManager.LoadScene("Testowa");

    }

    public void Upgrades_Scene()
    {
        GameObject.Find("Stats").GetComponent<Stats>().SaveDate();
        Debug.Log("Zapisano"+ Stats.gold + " + " + Stats.earned_gold);
        //Stats.earned_gold = 0;
        SceneManager.LoadScene("Upgrade");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
