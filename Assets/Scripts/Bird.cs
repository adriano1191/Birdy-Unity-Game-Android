using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public Transform[] transforms;
    
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    public float timeFly = 3;
    public static float flySpeed;
    Rigidbody2D rg;

    void Start () {
        Camera.main.GetComponent<CameraScript>().player = gameObject;
        Camera.main.GetComponent<CameraScript>().follow = true;
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
    }

    private void FixedUpdate()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BirdHurt"))
        {
            AnimationState(1);
        }

        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector2(transform.position.x, -2.8f);

        }
        if (timeFly <= 0 && !animator.GetBool("Grounded"))
        {
            AnimationState(1);
        }
        EndGame();

        
        //flySpeed = rig.velocity.x;
        // Debug.Log(flySpeed);

    }
    private void Update()
    {

        timeFly -= Time.deltaTime;
    }

    public void AnimationState(int animID)
    {
        switch (animID)
        {
            case 1: //IDLE
                animator.SetBool("Grounded", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Hurt", false);
                timeFly = 3;
                break;

            case 2: //JUMP
                timeFly = 3;
                animator.SetBool("Grounded", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Hurt", false);
                break;
            case 3: //Grounded
                timeFly = 3;
                animator.SetBool("Grounded", true);
                animator.SetBool("Hurt", false);
                break;
            case 4: //Hurt
                timeFly = 3;
                animator.SetBool("Grounded", false);
                //animator.SetBool("Idle", false);
                animator.SetBool("Hurt", true);
                
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetType() == typeof(BoxCollider2D))
        {
            if(collision.transform.tag == "Fruit")
            {
                collision.GetComponent<Fruits>().Fruit(collision.GetComponent<Fruits>().whatFruit);
            }
            if (collision.transform.tag == "CoinBag")
            {
                collision.GetComponent<CoinBag>().Coins(collision.GetComponent<CoinBag>().howMuch);
            }
            if (collision.transform.tag == "Crate")
            {
                collision.GetComponent<Crate>().CrateHit(collision.GetComponent<Crate>().power);
                AnimationState(4);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {

            AnimationState(3);


        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {

            AnimationState(3);


        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {

            AnimationState(1);


        }
    }

    public void SoundHelper(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }


    public void EndGame()
    {
        if(rg.velocity.x + rg.velocity.y == 0)
        {
            float timer = 3.0f;
            timer = -Time.deltaTime;
            if(timer <= 0)
            {
                GameObject.Find("Stats").gameObject.GetComponent<Stats>().SaveDate();
                GuiNumber.gui = 3;
            }
        }
        //Debug.Log(rg.velocity.x + rg.velocity.y);
    }
}
