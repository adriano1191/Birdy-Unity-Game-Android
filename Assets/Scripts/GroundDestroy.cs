using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour {


    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();

        groundHorizontalLength = groundCollider.size.x;
    }
    void Update()
    {
        if (Camera.main.transform.position.x > transform.position.x + groundHorizontalLength + 10)
        {
            Destroy(gameObject);
        }
    }

}
