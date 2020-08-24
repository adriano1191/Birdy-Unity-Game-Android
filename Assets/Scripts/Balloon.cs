using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    private Animator animator;
    private AnimatorStateInfo stateInfo;
    private Rigidbody2D rigid;
    private AudioSource src;
    public GameObject Rope;
    public AudioClip balloonAudio;

    public bool destroy = false;
    public float FloatStrenght;
    public float rand;
    public float max_x;
    public float min_x;

    void Start () {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            BalloonDestroy();
        }
    }



    private void FixedUpdate()
    {

        if (destroy)
        {
            BalloonDestroy();
            destroy = false;
        }
        if(rigid.velocity.x >= min_x && rigid.velocity.x <= max_x)
        {
            rand = Random.Range(min_x, max_x);

        }
        else if(rigid.velocity.x < max_x)
        {
            rand = Random.Range(min_x, 0.0f);

        }
        else if(rigid.velocity.x > min_x)
        {
            rand = Random.Range(0.0f, max_x);

        }
        rigid.AddForce(Vector2.left * rand);
        rigid.AddForce(Vector2.up * FloatStrenght);
    }

    private void BalloonDestroy()
    {
        FloatStrenght = 0.0f;
        if (Rope != null)
        {
            Rope.GetComponent<HingeJoint2D>().enabled = false;
        }
        src.PlayOneShot(balloonAudio);
        animator.SetBool("destroy", true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length -0.2f);
    }
}
