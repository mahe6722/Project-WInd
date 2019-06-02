using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComboDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cog")
        {
            counter++;
        }
    }
    int counter = 0;
	void Start ()
    {
		
	}

	void Update ()
    {
		
	}
}
