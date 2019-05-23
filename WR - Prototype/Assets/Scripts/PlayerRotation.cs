using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    GameObject mousePosLocator;
    MousePosXLocator mousePosLocatorScript;
    // Use this for initialization
    void Start ()
    {
        mousePosLocator = GameObject.Find("MousePosLocator");
        mousePosLocatorScript = mousePosLocator.GetComponent<MousePosXLocator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        faceMouse();
    }

    void faceMouse()
    {

        Vector2 direction = new Vector2(
            mousePosLocator.transform.position.x - gameObject.transform.position.x,
            mousePosLocator.transform.position.y - gameObject.transform.position.y
            );

        gameObject.transform.rotation = new Quaternion(0, 0, Mathf.Clamp(transform.rotation.z, -30, 30), 0); //doesnt work

        gameObject.transform.up = direction;
    }
}
