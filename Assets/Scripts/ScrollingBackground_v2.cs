using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground_v2 : MonoBehaviour
{

    public GameObject background_0;
    public GameObject background_1;
    public GameObject background_2;
    public GameObject background_3;
    public GameObject background_4;
    public GameObject background_5;
    public GameObject background_6;
    private GameObject bgObj_1;
    private GameObject bgObj_2;
    public float x;
    public float y;
    public float pos_x;
    public float pos_y;
    public float pos_x_Correct = 0;
    public float pos_x_Correct_Two = 0;
    public int count = 32;
    public List<GameObject> listBG_1;
    public List<GameObject> listBG_2;

    private int k = 0; // do sprawdzania renderera

    void Start()
    {
        listBG_1 = new List<GameObject>();
        listBG_2 = new List<GameObject>();

        //przesyla informacje do kamery
        Camera.main.GetComponent<CameraScript>().maxDist_count = count;

        x = background_0.GetComponent<SpriteRenderer>().bounds.size.x;
        y = background_0.GetComponent<SpriteRenderer>().bounds.size.y;


        //1 tło
        GameObject bgClone = Instantiate(background_0, transform.position, Quaternion.identity) as GameObject;
        bgClone.transform.parent = gameObject.transform;
        listBG_1.Add(bgClone);

        //2 tło
        GameObject bgClone2 = Instantiate(background_0, new Vector3(transform.position.x + x, transform.position.y, 10), Quaternion.identity) as GameObject;
        bgClone.transform.parent = gameObject.transform;
        listBG_2.Add(bgClone2);


        for (int i = 1; i < count; i++)
        {
            if (i < 16)
            {
                bgObj_1 = background_1;
                bgObj_2 = background_1;
            }
            else if (i == 16 )
            {
                bgObj_1 = background_2;
                bgObj_2 = background_2;
            }
            else if (i == 17)
            {
                bgObj_1 = background_3;
                bgObj_2 = background_3;
            }
            else if (i == 18)
            {
                bgObj_1 = background_4;
                bgObj_2 = background_4;
            }
            else if (i == 19)
            {
                bgObj_1 = background_5;
                bgObj_2 = background_5;
            }
            else if (i > 19)
            {
                bgObj_1 = background_6;
                bgObj_2 = background_6;
            }

            //1 tło
            GameObject skyClone = Instantiate(bgObj_1, new Vector3(transform.position.x, y * i, 10), Quaternion.identity) as GameObject;
            skyClone.transform.parent = gameObject.transform;
            listBG_1.Add(skyClone);

            //2
            GameObject skyClone2 = Instantiate(bgObj_2, new Vector3(transform.position.x + x, y * i, 10), Quaternion.identity) as GameObject;
            skyClone2.transform.parent = gameObject.transform;
            listBG_2.Add(skyClone2);
        }
        pos_x = x;
        pos_y = 0;

        Camera.main.GetComponent<CameraScript>().maxDist_y = y;

    }

    // Update is called once per frame
    void Update()
    {
       if(Camera.main.transform.position.x > listBG_1[0].transform.position.x + x)
        {
            foreach(GameObject BG1 in listBG_1)
            {
                BG1.transform.position = new Vector3(BG1.transform.position.x + (2 * x), BG1.transform.position.y, 10);
            }
        }
        if (Camera.main.transform.position.x > listBG_2[0].transform.position.x + x)
        {
            foreach (GameObject BG2 in listBG_2)
            {
                BG2.transform.position = new Vector3(BG2.transform.position.x + (2 * x), BG2.transform.position.y, 10);
            }
        }

        /*Visible(listBG_1[k]);
        Visible(listBG_2[k]);
        if(k == count - 1)
        {
            k = 0;
        }
        else
        {
            k++;
        }*/

    }

    private void Visible(GameObject bg)
    {
        if (bg.GetComponent<Renderer>().isVisible)
        {
            bg.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            bg.GetComponent<Renderer>().enabled = true;
        }
    }

}
