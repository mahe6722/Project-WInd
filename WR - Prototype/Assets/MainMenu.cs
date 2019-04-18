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
	void Update () {

        if (mastMovement.tilt > 0 && text_Play.color == colorPressed) {
            text_HighScores.color = colorPressed;
            text_Play.color = colorStart;
        }
        else if(mastMovement.tilt > 0 && text_HighScores.color == colorPressed) {
            text_MastCalibration.color = colorPressed;
            text_HighScores.color = colorStart;
        } 
        else if (mastMovement.tilt > 0 && text_MastCalibration.color == colorPressed) {
            text_Quit.color = colorPressed;
            text_MastCalibration.color = colorStart;
        }


        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
	}
}
