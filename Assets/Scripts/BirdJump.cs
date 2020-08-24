using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BirdJump : MonoBehaviour {

    Bird bird;
    public float jumpSpeed;
    public float flySpeed;
    public int limit;
    private float timer = 0.3f;

    private AudioSource audiosrc;
    public AudioClip flyAudio;

    //limit lotu 
    private float maxDist_y; //Wielkosc tla
    private float maxDist_count; //ile razy tlo jest generowane
    private float maxDist;

    void Start () {

        GameObject BG = GameObject.Find("BackGround");
        maxDist_y = BG.GetComponent<ScrollingBackground_v2>().y;
        maxDist_count = BG.GetComponent<ScrollingBackground_v2>().count;
        maxDist = maxDist_y * maxDist_count - (maxDist_y);//maksymalna wysokosc do uzywania skoku

        audiosrc = gameObject.GetComponent<AudioSource>();
         bird = GetComponent<Bird>();
        GameObject sStats = GameObject.Find("Stats");
        float jumpUpgrade = sStats.gameObject.GetComponent<Up_2>().jump_speed_upgrade;
        float flyUpgrade = sStats.gameObject.GetComponent<Up_3>().fly_speed_upgrade;
        flySpeed = 100f + flyUpgrade;
        jumpSpeed = 100f + jumpUpgrade;
        Debug.Log(jumpSpeed);

	}
    // Update is called once per frame
    void Update () {

        limit = Stats.energy;
        timer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {
        /*if (Cannon_Aim.itseditor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
        }*/

    }

    public void Jump()
    {
        if (limit > 0 && timer <= 0 && transform.position.y <= maxDist)
        {
            bird.AnimationState(2);
            Rigidbody2D rgBird = GetComponent<Rigidbody2D>();
            if (rgBird.velocity.y <= 0)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed * 2) * Time.deltaTime, ForceMode2D.Impulse);
                //Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed * 2) * Time.deltaTime + jumpSpeed);
            }
            else if (rgBird.velocity.y < 15 && rgBird.velocity.y > 0)
            {
                rgBird.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
                //Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed) * Time.deltaTime + jumpSpeed);
            }
            else if (rgBird.velocity.y >= 15 && rgBird.velocity.y < 20)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed / 2)* Time.deltaTime, ForceMode2D.Impulse);
                //Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed / 2) * Time.deltaTime + jumpSpeed);
            }
            else if(rgBird.velocity.y >= 20 && rgBird.velocity.y < 25)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed / 3) * Time.deltaTime, ForceMode2D.Impulse);
                //Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed / 3) * Time.deltaTime + jumpSpeed);
            }
            else if (rgBird.velocity.y >= 25 && rgBird.velocity.y < 30)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed / 4) * Time.deltaTime, ForceMode2D.Impulse);
                //Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed / 4) * Time.deltaTime + jumpSpeed);
            }
            else if (rgBird.velocity.y >= 30)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed / 5) * Time.deltaTime, ForceMode2D.Impulse);
               // Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed / 5) * Time.deltaTime + jumpSpeed);
            }
            else if (rgBird.velocity.y >= 40)
            {
                rgBird.AddForce(Vector2.up * (jumpSpeed / 10) * Time.deltaTime, ForceMode2D.Impulse);
                // Debug.Log(rgBird.velocity.y + " + " + Vector2.up * (jumpSpeed / 5) * Time.deltaTime + jumpSpeed);
            }



            if (rgBird.velocity.x <= 0)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 2) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed * 2) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x < 15 && rgBird.velocity.x > 0)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 5 )* Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 5) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x >= 15 && rgBird.velocity.x < 20)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 10) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 10) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x >= 20 && rgBird.velocity.x < 25)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 15) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 15) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x >= 25 && rgBird.velocity.x < 30)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 20) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 20) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x >= 30)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 25) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 25) * Time.deltaTime + flySpeed);
            }
            else if (rgBird.velocity.x >= 40)
            {
                rgBird.AddForce(Vector2.right * (flySpeed / 50 * 0) * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 50) * Time.deltaTime + flySpeed);
            }
            //rgBird.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //rgBird.AddForce(Vector2.right * (flySpeed / 10) * Time.deltaTime, ForceMode2D.Impulse);
            //Debug.Log(rgBird.velocity.x + " + " + Vector2.right * (flySpeed / 10) * Time.deltaTime + flySpeed);

            //Debug.Log("Jump" + Vector2.up * (jumpSpeed / 6) * Time.deltaTime);
            Stats.energy = Stats.energy - 1;

            timer = 0.15f;

            audiosrc.PlayOneShot(flyAudio);
        }
    }
}
