using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text text_Play;
    public Text text_HighScores;
    public Text text_MastCalibration;
    public Text text_Quit;
    public GameObject textMainMenu;

    public Color colorStart;
    public Color colorPressed;

    public MastMovement mastMovement;

    // Use this for initialization
    void Start () {

        colorStart = text_Quit.color;
        colorPressed = text_Play.color;

    }
	
	// Update is called once per frame
	void Update ()
    {
        HighlightMenuButtons();

        if (Input.GetKey(KeyCode.Space) && textMainMenu.activeInHierarchy == true) {

            if(text_Play.color == colorPressed) {
            SceneManager.LoadScene(1);
            }

            if(text_HighScores.color == colorPressed) {
                print("SHOWING HIGHSCORES");
            }

            if (text_MastCalibration.color == colorPressed) {
                print("CALIBRATE MAST");
            }

            if(text_Quit.color == colorPressed) {
                Application.Quit();
            }
        }

    }

    private void HighlightMenuButtons()
    {
        if (mastMovement.tilt < 10) {
            text_Play.color = colorPressed;
            text_HighScores.color = colorStart;
            text_MastCalibration.color = colorStart;
            text_Quit.color = colorStart;
        }
        if (mastMovement.tilt > 10) {
            text_Play.color = colorStart;
            text_HighScores.color = colorPressed;
            text_MastCalibration.color = colorStart;
            text_Quit.color = colorStart;
        }
        if (mastMovement.tilt > 20) {
            text_Play.color = colorStart;
            text_HighScores.color = colorStart;
            text_MastCalibration.color = colorPressed;
            text_Quit.color = colorStart;
        }
        if (mastMovement.tilt > 30) {
            text_Play.color = colorStart;
            text_HighScores.color = colorStart;
            text_MastCalibration.color = colorStart;
            text_Quit.color = colorPressed;
        }
    }
}
