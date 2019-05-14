using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BluePrintScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.anyKey || Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene("GameScene");
        }
	}
}
