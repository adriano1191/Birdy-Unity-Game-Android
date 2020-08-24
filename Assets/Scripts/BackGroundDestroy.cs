using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.x > transform.position.x + 20)
        {
            Destroy(gameObject);
        }
    }
}
