using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    GameObject mousePosLocator;
    MousePosXLocator mousePosLocatorScript;
    public float offset;
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

        Vector2 direction = new Vector2(
            mousePosLocator.transform.position.x - gameObject.transform.position.x,
            mousePosLocator.transform.position.y - gameObject.transform.position.y
            );

        //gameObject.transform.rotation = new Quaternion(0, 0, Mathf.Clamp(transform.rotation.z, -30, 30), 0); //doesnt work
        Mathf.Clamp(transform.rotation.eulerAngles.z, -30, 30);
        gameObject.transform.up = direction;
    }
}
