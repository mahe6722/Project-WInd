using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint_PlayerTilt : MonoBehaviour {

    //public static float tilt;
    public bool maxTiltRight;
    public bool maxTiltLeft;

    public float overTilt = 0;
    private int mouseDirection;

    Rigidbody2D playerRigidBody;
    GameObject player;

    public float turnSpeed;

    public float inputMouseX; //Debug Mouse Input

    void Start()
    {
        player = GameObject.Find("BluePrint_Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
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
        
            MastMovement.tilt += mouseDirection;
            
        

        
    }

    void PlayerTurning()
    {
        
        if (MastMovement.tilt != 0) {
            //player.transform.Translate(turnSpeed * (MastMovement.tilt / 100) * Time.deltaTime, 0f, 0f, Space.World);
        }
        
        //Clamp Player between -8 and 8 on screen.
        var playerPosition = player.transform.position;
        
        playerPosition.x = Mathf.Clamp(player.transform.position.x, -0f, 0f);
        player.transform.position = playerPosition;

        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, turnSpeed * (MastMovement.tilt / 25) * -1);

        var playerRotation = player.transform.rotation;

        if (transform.localRotation.z < -0.19f) {
            print("OVER RIGHT");
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -20f);
        }
        if (transform.localRotation.z > 0.19f) {
            print("OVER RIGHT");
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 20f);
        }



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