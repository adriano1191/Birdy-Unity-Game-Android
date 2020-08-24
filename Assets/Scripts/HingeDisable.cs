using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeDisable : MonoBehaviour {

    private HingeJoint2D hinge;

	void Start () {
        hinge = gameObject.GetComponent<HingeJoint2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {

           hinge.enabled = false;

        }
    }
}
