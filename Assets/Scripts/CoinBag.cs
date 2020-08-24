using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBag : MonoBehaviour {

    public int howMuch;
    private AudioSource audiosrc;
    public AudioClip sound;
    private bool click = false;

    void Start () {
		howMuch = Random.Range(5, 25);
        audiosrc = gameObject.GetComponent<AudioSource>();
    }
	

	void Update () {
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
                if (hit.collider != null && hit.transform.tag == "CoinBag")
                {
                    Debug.Log("I'm hitting " + hit.collider.name);
                    hit.transform.gameObject.GetComponent<CoinBag>().Coins(howMuch);
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
                    hit.transform.gameObject.GetComponent<CoinBag>().Coins(howMuch);
                }
            }
        }
#endif

    }

    public void Coins(int coin)
    {
        if (!click)
        {

            Stats.earned_gold += coin;
            Debug.Log("Dodano: " + coin + " zlota");

            audiosrc.PlayOneShot(sound);
            gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, sound.length);
            click = true;
        }
    }
}
