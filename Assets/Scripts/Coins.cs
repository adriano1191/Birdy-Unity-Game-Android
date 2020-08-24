using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {



    public AudioClip coin;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Camera.main.transform.position.x > transform.position.x + 20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //collision.GetComponent<Bird>().SoundHelper(coin); //odtwarzanie dzwieki w innym obiekcie
            Stats.earned_gold++;
            audioSource.PlayOneShot(coin);
            gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, coin.length);
            //Destroy(gameObject);
        }
        else if(collision.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }
}
