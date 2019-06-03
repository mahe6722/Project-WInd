using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    GameObject mousePosLocator;
    MousePosXLocator mousePosLocatorScript;
    public float offset;
    public float negativeOffset;
    // Use  this for initialization
    void Start ()
    {
        mousePosLocator = GameObject.Find("MousePosLocator");
        mousePosLocatorScript = mousePosLocator.GetComponent<MousePosXLocator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        faceMouseX();
    }

    void faceMouseX()
    {
        if (mousePosLocator.transform.position.x - gameObject.transform.position.x == 0) {
            print("Points straight up");
            offset = 0f;
        }

        if(mousePosLocator.transform.position.x > 0) {
            //offset = 3f;
            offset = Mathf.Pow(mousePosLocator.transform.position.x, 2f);
            if(offset > 3) {
                offset = 3f;
            }

            print("Left Offset is:" + offset);
        }
        if (mousePosLocator.transform.position.x < 0) {
            //offset = -3;
            print("Right Offset is:" + offset);
            negativeOffset = Mathf.Pow(mousePosLocator.transform.position.x, 2f);
            offset = -negativeOffset;
            if (offset < -3) {
                offset = -3f;
            }
        }


        Vector2 direction = new Vector2(
            mousePosLocator.transform.position.x - gameObject.transform.position.x + offset,
            mousePosLocator.transform.position.y - gameObject.transform.position.y
            );

        //gameObject.transform.rotation = new Quaternion(0, 0, Mathf.Clamp(transform.rotation.z, -30, 30), 0); //doesnt work
        Mathf.Clamp(transform.rotation.eulerAngles.z, -30, 30);
        gameObject.transform.up = direction;
    }
}
