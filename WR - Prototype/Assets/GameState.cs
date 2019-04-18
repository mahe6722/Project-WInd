using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public bool gameOver;

    public GameObject player;
    public GameObject restartMenu;
	
	// Update is called once per frame
	void Update () {
		if (player.activeInHierarchy == false) {
            gameOver = true;
        }

        if (gameOver) {
            restartMenu.SetActive(true);
        }
	}
}
