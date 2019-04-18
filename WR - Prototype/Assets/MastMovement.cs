using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastMovement : MonoBehaviour {

    public float tilt = 0;
    public float overTilt = 0;
    private int mouseDirection;

    public GameObject player;

	
	// Update is called once per frame
	void Update () {

        CheckMouseDirection();
        DetermineTilt();
	}

    void DetermineTilt()
    {
        //Add mouseDirection to tilt to measure the placement of Mast!
            tilt += mouseDirection;
    }

    void CheckMouseDirection()
    {
        if (Input.GetAxis("Mouse X") > 0) {
            mouseDirection = 1;
        }
        if (Input.GetAxis("Mouse X") < 0) {
            mouseDirection = -1;
        }
        if (Input.GetAxis("Mouse X") == 0) {
            mouseDirection = 0;
        }
    }
}

