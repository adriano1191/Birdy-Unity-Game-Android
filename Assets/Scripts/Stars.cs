using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SoundsPlayMute))]
public class Stars : MonoBehaviour {

    public AudioClip starClip;
    private AudioSource audSrc;

    private SpriteRenderer rendering;
    public List<Sprite> starList;
    private int maxList;

    public int starNumber;
    private int gold;
    private int energy;
    private GameObject sStats;


    void Start () {
        audSrc = GetComponent<AudioSource>();
        sStats = GameObject.FindGameObjectWithTag("Stats");
        rendering = GetComponent<SpriteRenderer>();
        maxList = starList.Count;
        starNumber = Random.Range(0, maxList);
        Spawn();
        
	}
	

	void Update () {
        if (Camera.main.transform.position.x > transform.position.x + 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetStar();
        }
    }

    private void GetStar()
    {
        if(starNumber == 0 || starNumber == 1)
        {
            gold = 1;
            energy = 1;
        }
        else if(starNumber == 2)
        {
            gold = 1;
            energy = 3;
        }
        else if(starNumber == 3)
        {
            gold = 3;
            energy = 1;
        }
        else
        {
            gold = 3;
            energy = 3;
        }

        Stats.earned_gold += gold;

        if (Stats.energy >= Stats.energyMax)
        {
            Stats.energy = Stats.energyMax;
        }
        else
        {
            Stats.energy += energy;
        }

        audSrc.PlayOneShot(starClip);
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, starClip.length);
    }

    private void Spawn()
    {
        
        rendering.sprite = starList[starNumber];
        
    }
}
