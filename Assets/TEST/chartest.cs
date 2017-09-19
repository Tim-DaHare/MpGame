using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartest : MonoBehaviour {

    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        controller.Move((Vector3.down * 5) * Time.deltaTime);
		
	}
}
