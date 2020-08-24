using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour {

    public bool press = false;
    public Sprite BirdPressed;
    public Sprite BirdUnPlressed;
    private GameObject Bird;
	
	// Update is called once per frame
	void Update () {
        if (press)
        {
            gameObject.GetComponentInChildren<Image>().sprite = BirdPressed;
        }
        else
        {
            gameObject.GetComponentInChildren<Image>().sprite = BirdUnPlressed;
        }

        if(Bird == null)
        {
            Bird = GameObject.Find("Bird(Clone)");
        }

        if (Stats.shooted)
        {
            gameObject.SetActive(true);

        }
    }

    public void PointerUp()
    {
        press = false;
    }
    public void PointerDown()
    {
        press = true;
    }

    public void Jump()
    {
        //GameObject.Find("Bird(Clone)").gameObject.GetComponent<BirdJump>().Jump();
        Bird.GetComponent<BirdJump>().Jump();
    }
}
