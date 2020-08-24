using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour {

    public static string mlog;
    public Text logText;
    private Text txtRef;
    void Start () {

        txtRef = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        //Transform child = transform.Find("Text");
        //Text t = child.GetComponent<Text>();


        txtRef.text = mlog;
    }
}
