using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour {

    public float moveDirection;
    public float joystickSpeed;

    public bool joystickActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0) {
            print("joystick right");
            joystickActive = true;
            moveDirection = Input.GetAxis("Horizontal");

        }
        if (Input.GetAxis("Horizontal") < 0) {
            print("joystick left");
            joystickActive = true;
            moveDirection = Input.GetAxis("Horizontal");
        }

        transform.Translate(moveDirection * joystickSpeed, 0, 0);

        if (Input.GetAxis("XboxTriggerLeft") > 0) {
            print("using left trigger");
            joystickActive = true;
        }

        if (Input.GetAxis("XboxTriggerRight") < 0) {
            print("using right trigger");
            joystickActive = true;
        }

        if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0){
            joystickActive = true;
        }

        if(Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Z)) {
            joystickActive = false;
        }

    }
}
