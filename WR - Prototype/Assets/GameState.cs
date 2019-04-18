using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public bool gameOver;

    public GameObject player;
    public GameObject restartMenu;
    public GameObject text_restartMenu;
    public Image background_restartMenu;

    PlayerFuel playerFuel;

    public float flashSpeed;

    void Start()
    {
        playerFuel = GameObject.Find("Player").GetComponent<PlayerFuel>();
    }

    // Update is called once per frame
    void Update () {
		if (player.activeInHierarchy == false || playerFuel.playerFuel <= 0f ) {
            gameOver = true;
        }

        if (gameOver) {
            restartMenu.SetActive(true);
            text_restartMenu.SetActive(false);
            background_restartMenu.color = Color.Lerp(background_restartMenu.color, new Color(0, 0, 0, 1), flashSpeed * Time.deltaTime);

            if (background_restartMenu.color.a >= 0.95f) {
                text_restartMenu.SetActive(true);
            }
        }
	}
}
