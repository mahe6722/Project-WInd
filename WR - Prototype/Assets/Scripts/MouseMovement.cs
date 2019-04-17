using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public float tilt = 0;
    public float overTilt = 0;
    private int mouseDirection;

    Rigidbody2D playerRigidBody;

    public float turnSpeed;

    public float inputMouseX; //Debug Mouse Input

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {       
        inputMouseX = Input.GetAxis("Mouse X"); //Debug Mouse Input

        CheckMouseDirection();

        DetermineTilt();

        //If Mast is not straight, Turn!
        PlayerTurning();
    }

    void DetermineTilt()
    {
        //Add mouseDirection to tilt to measure the placement of Mast!
        if (transform.position.x < 8 && transform.position.x > -8) {
            tilt += mouseDirection;
        } 

        //If Player has reached edge of screen. Mast is overTilting!
        else if (transform.position.x >= 8 || transform.position.x <= -8) {
            overTilt += mouseDirection;
        }

        //Check if Overtilted mast has returned to the furthest edge of the intended tilt!
        if (transform.position.x <= -8 && overTilt > 0) {
            tilt += overTilt;

            overTilt = 0;
        }
        if (transform.position.x >= 8 && overTilt < 0) {
            tilt += overTilt;

            overTilt = 0;
        }
    }

    void PlayerTurning()
    {
        if (tilt != 0) {
            transform.Translate(turnSpeed * (tilt / 100) * Time.deltaTime, 0f, 0f, Space.World);
        }

        //Clamp Player between -8 and 8 on screen.
        var playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(transform.position.x, -4f, 4f);
        transform.position = playerPosition;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, turnSpeed * (tilt / 25) * -1);
        
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
