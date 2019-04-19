using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

    public Text text_Restart;
    public Text text_MainMenu;
    public GameObject textRestartMenu;

    public Color colorStart;
    public Color colorPressed;

    public MouseMovement mastMovement;

    void Start()
    {

       colorStart = text_MainMenu.color;
       colorPressed = text_Restart.color;
    
       
    }

    // Update is called once per frame
    void Update ()
    {
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
        if (mastMovement.tilt > 10) {
            text_MainMenu.color = colorPressed;
            text_Restart.color = colorStart;
        }
        if (mastMovement.tilt < 10) {
            text_Restart.color = colorPressed;
            text_MainMenu.color = colorStart;
        }
    }
}
