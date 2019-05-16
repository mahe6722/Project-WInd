using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    //public static float tilt;
    public float overTilt = 0;
    private int mouseDirection;

    Rigidbody2D playerRigidBody;
    GameObject player;

    public float turnSpeed;

    public float inputMouseX; //Debug Mouse Input

    void Start()
    {
        player = GameObject.Find("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
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
        if (player.transform.position.x < 4 && player.transform.position.x > -4) {
            MastMovement.tilt += mouseDirection;
        } 

        //If Player has reached edge of screen. Mast is overTilting!
        else if (player.transform.position.x >= 4 || player.transform.position.x <= -4) {
            overTilt -= mouseDirection;
        }

        //Check if Overtilted mast has returned to the furthest edge of the intended tilt!
        if (player.transform.position.x <= -4 && overTilt > 0) {
            MastMovement.tilt -= overTilt;

            overTilt = 0;
        }
        if (player.transform.position.x >= 4 && overTilt < 0) {
            MastMovement.tilt -= overTilt;

            overTilt = 0;
        }
    }

    void PlayerTurning()
    {
        if (MastMovement.tilt != 0) {
            player.transform.Translate(turnSpeed * (-MastMovement.tilt / 100) * Time.deltaTime, 0f, 0f, Space.World);
        }

        //Clamp Player between -8 and 8 on screen.
        var playerPosition = player.transform.position;
        playerPosition.x = Mathf.Clamp(player.transform.position.x, -4f, 4f);
        player.transform.position = playerPosition;

        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, turnSpeed * (-MastMovement.tilt / 25) * -1);
        
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
