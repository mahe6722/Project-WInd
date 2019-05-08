using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbackground : MonoBehaviour
{

    public float speed = 1f; // for background speed movement
    public float clamppos ; // for clamping position
    public Config configScript;

    public Vector2 startPosition; // Get our first position

	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
	}
	
    void FixedUpdate()
    {
        speed = configScript.speed;
        float newPosition = Mathf.Repeat(Time.time * configScript.speed, clamppos);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}
