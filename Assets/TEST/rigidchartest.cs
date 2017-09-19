using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidchartest : MonoBehaviour {

    float gravity = 1000f;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = Vector3.down;
        dir = transform.TransformDirection(dir);
        dir.y -= gravity;
        rb.velocity = dir * Time.deltaTime;
	}
}
