using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CloudDark : MonoBehaviour {

    private GameObject bird;
    private GameObject sStats;
    private float flyUpgrade;
    private float jumpUpgrade;
    private float birdSpeed;
    private float birdSpeedJump;

    private void Start()
    {
        sStats = GameObject.FindGameObjectWithTag("Stats");
        flyUpgrade = sStats.gameObject.GetComponent<Up_3>().fly_speed_upgrade;
        jumpUpgrade = sStats.gameObject.GetComponent<Up_2>().jump_speed_upgrade;
        transform.position = new Vector3(transform.position.x, transform.position.y, -9);
    }

    private void Update()
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
                if (hit.collider != null && hit.transform.tag == "DarkCloud")
                {
                    Debug.Log("I'm hitting " + hit.collider.name);
                    CloudDarkTapping();
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
                    hit.transform.gameObject.GetComponent<CloudDark>().CloudDarkTapping();
                }
            }
        }
#endif

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            collision.attachedRigidbody.AddForce(-3.1F * collision.attachedRigidbody.velocity);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bird = collision.gameObject;
            birdSpeed = bird.GetComponent<Rigidbody2D>().velocity.x * 0.8f;
            birdSpeedJump = bird.GetComponent<Rigidbody2D>().velocity.y * 0.8f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bird = null;
    }

    public void CloudDarkTapping()
    {
        if (bird != null)
        {
            if(bird.GetComponent<Rigidbody2D>().velocity.x < birdSpeed)
            {

                bird.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (100 + flyUpgrade) * 2 * Time.deltaTime, ForceMode2D.Impulse);
                    if (bird.GetComponent<Rigidbody2D>().velocity.y < birdSpeedJump)
                    {

                        bird.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (100f + jumpUpgrade / 20) * Time.deltaTime, ForceMode2D.Impulse);

                    }
                bird.GetComponent<Bird>().AnimationState(2);
                bird.GetComponent<AudioSource>().PlayOneShot(bird.GetComponent<BirdJump>().flyAudio);

            }
            //bird.GetComponent<BirdJump>().Jump();
        }

        Debug.Log("Jump");
    }
}
