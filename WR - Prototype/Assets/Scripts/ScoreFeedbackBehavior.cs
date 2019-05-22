using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFeedbackBehavior : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        //If the position of the gameObject is not the same as the "Hierachy Placeholder" Destroy the object it has been instantiated.
        if(transform.position.y != -50) {
        Destroy(gameObject, 0.5f);
        }
	}
}
