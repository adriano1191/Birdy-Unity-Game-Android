using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour {

    private bool record = false;
    public GameObject recordText;
    public void NewRecord(int dist)
    {
        Debug.Log("Record: " + Stats.max_distance);
        if(dist > Stats.max_distance)
        {
            record = true;
            recordText.SetActive(true);
            Stats.max_distance = dist;
            GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
        }
    }
}
