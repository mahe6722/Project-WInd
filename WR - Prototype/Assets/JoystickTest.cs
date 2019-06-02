using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour {

    public float moveDirection;
    public float joystickSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0) {
            print("joystick right");
            moveDirection = Input.GetAxis("Horizontal");

        }
        if (Input.GetAxis("Horizontal") < 0) {
            print("joystick left");
            moveDirection = Input.GetAxis("Horizontal");
        }

        transform.Translate(moveDirection * joystickSpeed, 0, 0);
    }
}
