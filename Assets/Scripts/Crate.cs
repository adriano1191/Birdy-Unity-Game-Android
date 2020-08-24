using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

    public int power;
    private AudioSource audiosrc;
    public AudioClip sound;
    public AudioClip soundDestroy;

    void Start()
    {
        power = Random.Range(10, 50);
        audiosrc = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Camera.main.transform.position.x > transform.position.x + 20)
        {

            Destroy(gameObject);
        }
        Interaction();
    }

    private void Interaction()
    {
#if UNITY_EDITOR
        if (Time.timeScale == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {

                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null && hit.transform.tag == "Crate")
                {
                    Debug.Log("I'm hitting " + hit.collider.name);
                    hit.transform.gameObject.GetComponent<Crate>().CrateDestroy();
                }
            }
        }

#else
        if(Time.timeScale == 1)
        {
            if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
                if (hit.collider != null)
                {
                    hit.transform.gameObject.GetComponent<Crate>().CrateDestroy();
                }
            }
        }
#endif

    }

    public void CrateHit(int pow)
    {

        GameObject Bird = GameObject.FindWithTag("Player");
        Bird.GetComponent<Rigidbody2D>().velocity *= 0.7f;


        audiosrc.PlayOneShot(sound);
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, sound.length);
    }

    private void CrateDestroy()
    {
        audiosrc.PlayOneShot(soundDestroy);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject,soundDestroy.length);
    }
}
