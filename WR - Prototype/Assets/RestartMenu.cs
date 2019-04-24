using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

    public Text text_yourScore;
    public Text text_Restart;
    public Text text_MainMenu;
    public GameObject textRestartMenu;

    public Color colorStart;
    public Color colorPressed;

    public Color colorStart_yourScore;
    public SpriteRenderer flashColorScore;

    public float flashTimer;
    public float flashSpeed;
    public float flashDuraction;

    public MouseMovement mastMovement;
    public Config configScript;

    void Start()
    {

       colorStart = text_MainMenu.color;
       colorPressed = text_Restart.color;

       colorStart_yourScore = text_yourScore.color;


    }

    // Update is called once per frame
    void Update ()
    {
        flashTimer += Time.deltaTime;

        text_yourScore.text = "YOUR SCORE: " + configScript.score.ToString();

        if (text_yourScore.color == colorStart_yourScore) {

            text_yourScore.color = flashColorScore.color;

        }

        if (text_yourScore.color != colorStart_yourScore && flashTimer >= flashDuraction) {
            text_yourScore.color = Color.Lerp(text_yourScore.color, colorStart_yourScore, (flashSpeed * 4) * Time.deltaTime);

            if (text_yourScore.color == colorStart_yourScore) {
                flashTimer = 0f;
            }
        }


        HighlightMenuButtons();

        MenuButtonInteraction();

    }

    private void MenuButtonInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textRestartMenu.activeInHierarchy == true) {

            //If RESTART is highlighted, Restart Game.
            if (text_Restart.color == colorPressed) {

                SceneManager.LoadScene(1);
            }
            //If MAIN MENU is highlighted, Back to Main Menu.
            if (text_MainMenu.color == colorPressed) {
                SceneManager.LoadScene(0);
            }

        }
    }

    private void HighlightMenuButtons()
    {
        if (MastMovement.tilt > 10) {
            text_MainMenu.color = colorPressed;
            text_Restart.color = colorStart;
        }
        if (MastMovement.tilt < 10) {
            text_Restart.color = colorPressed;
            text_MainMenu.color = colorStart;
        }
    }
}
