using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{

    public GameObject scrollObj;
    public BoxCollider2D scrollCollider;
    public float scrollHorizontalLength;      
    private float pos_x;
    public float pos_x_Correct = -20;
    public float pos_x_Correct_Two = -20;

    private void Awake()
    {
        scrollCollider = scrollObj.GetComponent<BoxCollider2D>();

        scrollHorizontalLength = scrollCollider.size.x;

        GameObject groundClone = Instantiate(scrollObj, transform.position, Quaternion.identity) as GameObject;
        groundClone.transform.parent = gameObject.transform;
        pos_x = scrollHorizontalLength - 6;
    }


    private void Update()
    {
        if(Camera.main.transform.position.x > pos_x - 20)
        {
            
            GameObject groundClone = Instantiate(scrollObj, new Vector3(pos_x, transform.position.y, 0), Quaternion.identity) as GameObject;
            groundClone.transform.parent = gameObject.transform;
            pos_x += scrollHorizontalLength;
        }
    }
}