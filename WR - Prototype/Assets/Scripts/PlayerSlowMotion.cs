using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlowMotion : MonoBehaviour {

    public float slowMotionFactor = 0.05f;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else 
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
	}
}
