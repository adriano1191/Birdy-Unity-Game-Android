using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVersion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = "Game version:\n" + Application.version;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
