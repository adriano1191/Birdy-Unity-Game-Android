using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public GameObject background_1;
    public GameObject background_2;
    public float x;
    public float y;
    public float pos_x;
    public float pos_y;
    public float pos_x_Correct = 0;
    public float pos_x_Correct_Two = 0;
    private int count = 24;

    void Start () {

        Camera.main.GetComponent<CameraScript>().maxDist_count = count;
        x = background_1.GetComponent<SpriteRenderer>().bounds.size.x;
        y = background_1.GetComponent<SpriteRenderer>().bounds.size.y;
        GameObject bgClone = Instantiate(background_1, transform.position, Quaternion.identity) as GameObject;
        bgClone.transform.parent = gameObject.transform;
        for (int i = 1; i < count; i++)
        {
            GameObject skyClone = Instantiate(background_2, new Vector3(transform.position.x, y * i, 10), Quaternion.identity) as GameObject;
            skyClone.transform.parent = gameObject.transform;
        }
        pos_x = x;
        pos_y = 0;

        Camera.main.GetComponent<CameraScript>().maxDist_y = y;
    }
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.x > pos_x - 20)
        {

            GameObject groundClone = Instantiate(background_1, new Vector3(pos_x, pos_y, 10), Quaternion.identity) as GameObject;
            groundClone.transform.parent = gameObject.transform;
            

            for (int i = 1; i < count; i++)
            {
                GameObject skyClone = Instantiate(background_2, new Vector3(pos_x, y * i, 10), Quaternion.identity) as GameObject;
                skyClone.transform.parent = gameObject.transform;
            }
            pos_x += x;
        }
        /* if (Camera.main.transform.position.y > pos_y - 10)
         {

             GameObject groundClone = Instantiate(background, new Vector3(pos_x - x, pos_y, 10), Quaternion.identity) as GameObject;
             groundClone.transform.parent = gameObject.transform;
             pos_y += y;
         }
         else if (Camera.main.transform.position.y < pos_y - y - 5 )
         {
             Debug.Log(pos_y - y - 5);
             GameObject groundClone = Instantiate(background, new Vector3(pos_x - x, pos_y - y, 10), Quaternion.identity) as GameObject;
             groundClone.transform.parent = gameObject.transform;
             pos_y -= y;
         }*/

    }
}
