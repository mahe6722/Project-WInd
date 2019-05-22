using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public GameObject player;

    GameState gameStateScript;

    public GameObject warningFuel;

	// Use this for initialization
	void Start () {
        gameStateScript = GameObject.Find("GameState").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStateScript.gameOver == true){
            warningFuel.SetActive(false);
        };
	}
}
