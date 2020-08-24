using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {

    private int rand;
    public Sprite sprite_fruit_0;
    public Sprite sprite_fruit_1;
    public Sprite sprite_fruit_2;
    public int whatFruit;
    private bool check = false; //zapobiega wielokrotenmu wykonaniu skryptu

    private AudioSource audiosrc;
    public AudioClip sound;

    void Start () {

        audiosrc = gameObject.GetComponent<AudioSource>();
        rand = Random.Range(0, 10);
        if(rand >= 0 && rand < 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite_fruit_0;
            whatFruit = 0;
        }
        else if(rand >= 5 && rand < 8)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite_fruit_1;
            whatFruit = 1;
        }
        else if(rand >= 8 && rand <= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite_fruit_2;
            whatFruit = 2;
        }


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
        if(Time.timeScale == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {

                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null && hit.transform.tag == "Fruit")
                {
                    Debug.Log("I'm hitting " + hit.collider.name);
                    hit.transform.gameObject.GetComponent<Fruits>().Fruit(whatFruit);
                    //Fruit(whatFruit);
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
                    hit.transform.gameObject.GetComponent<Fruits>().Fruit(whatFruit);
                }
            }
        }
#endif

    }


    private void EnergyGain(int energy)
    {
        if(Stats.energy >= Stats.energyMax)
        {
            Stats.energy = Stats.energyMax;
        }
        else
        {
            Stats.energy += energy;
        }
        Debug.Log("Dodano Energie " + energy + "obecnie: " + Stats.energy);
        audiosrc.PlayOneShot(sound);
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, sound.length);
        //Destroy(gameObject);



    }

    public void Fruit(int fruit)
    {
        if (!check)
        {

            if(whatFruit == 0)
            {
                Fruit_0();
            }
            else if (whatFruit == 1)
            {
                Fruit_1();
            }
            else if (whatFruit == 2)
            {
                Fruit_2();
            }
            check = true;
        }
    }

    private void Fruit_0()
    {
        EnergyGain(1);
    }

    private void Fruit_1()
    {
        EnergyGain(2);
    }

    private void Fruit_2()
    {
        EnergyGain(3);
    }



}
