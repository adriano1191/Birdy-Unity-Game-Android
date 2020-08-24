using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public Transform playerPosition;
    public Vector3 offsetCamera;
    public float cameraSpeed;
    public bool follow = false;
    public float maxDist_y; //Wielkosc tla
    public float maxDist_count; //ile razy tlo jest generowane
    private float maxDist;

    public Vector2 test;

    void Update()
    {
        if (follow)
        {
            playerPosition = player.transform;
            if (playerPosition.position.x >= -2 || playerPosition.position.y >= 0)
            {
                transform.position = new Vector3(playerPosition.position.x + offsetCamera.x + 2, playerPosition.position.y + offsetCamera.y, -10); // Camera follows the player with specified offset position
                test = transform.position - playerPosition.position;

                maxDist = maxDist_y * maxDist_count - (maxDist_y);


                if (transform.position.x < 0)
                {
                    transform.position = new Vector3(0, transform.position.y, -10);
                }
                if (transform.position.y < 0)
                {
                    transform.position = new Vector3(transform.position.x, 0, -10);
                }
                if(transform.position.y >= maxDist)
                {
                    transform.position = new Vector3(transform.position.x, maxDist, -10);
                }

            }
        }
    }
    }

