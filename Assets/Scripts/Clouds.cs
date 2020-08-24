using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public Sprite cloudSprite_0;
    public Sprite cloudSprite_1;
    public Sprite cloudSprite_2;
    public Sprite cloudSprite_3;
    public Sprite cloudSprite_4;
    public Sprite cloudSprite_5;
    public Sprite cloudSprite_6;

    private Rigidbody2D rb;
    public float speed;
    private SpriteRenderer rendering;
    private float startPos_y;
    private List<Sprite> cloudsList;
    private int r;

    private string cloudSize;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rendering = GetComponent<SpriteRenderer>();
        startPos_y = transform.position.y;
        cloudsList = new List<Sprite>();
        cloudsList.Add(cloudSprite_0);
        cloudsList.Add(cloudSprite_1);
        cloudsList.Add(cloudSprite_2);
        cloudsList.Add(cloudSprite_3);
        cloudsList.Add(cloudSprite_4);
        cloudsList.Add(cloudSprite_5);
        cloudsList.Add(cloudSprite_6);

        r = Random.Range(0, 7);

        rendering.sprite = cloudsList[r];



    }

    private void Update()
    {
       // CloudsRender();
       // CloudMove();

    }

    private void FixedUpdate()
    {
        CloudsRender();
        CloudMove();
    }


    private void CloudsRender()
    {
        if (Camera.main.transform.position.x > transform.position.x + 15)
        {
            int r = Random.Range(0, 7);

            rendering.sprite = cloudsList[r];

            float y = Random.Range(-2, 2);
            transform.position = new Vector3(Camera.main.transform.position.x + 10, startPos_y + y, 8f);

            // Wielkosc chmur
            // Big - 6
            // Med - 0, 5
            // Small - 1, 2, 3, 4

        }
    }

    private void CloudMove()
    {
        if (r >= 6)
        {
            cloudSize = "BIG";
        }
        else if (r == 0 || r == 5)
        {
            cloudSize = "MED";
        }
        else
        {
            cloudSize = "SMALL";
        }

        switch (cloudSize)
        {
            case "BIG":
                speed = Random.Range(-10f, -15f);
                break;
            case "MED":
                speed = Random.Range(-20f, -30f);
                break;
            case "SMALL":
                speed = Random.Range(-35f, -45f);
                break;
        }

        Vector2 move = new Vector2(speed * Time.deltaTime, 0);
        rb.velocity = move;
    }

}
