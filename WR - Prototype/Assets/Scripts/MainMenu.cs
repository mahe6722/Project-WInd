using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Image image_Play;
    public Image image_HighScores;
    
   // public GameObject textMainMenu;

    public Color colorHighlight;
    public Color colorNotPressed;

   

    // Use this for initialization
    void Start () {

        colorHighlight = image_Play.color;
        colorNotPressed = image_HighScores.color;

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //Tilt Right to scroll down, Tilt back towards middle to scroll up!
        HighlightMenuButtons();
        MenuButtonInteractions();

    }

    private void MenuButtonInteractions()
    {
        if (Input.anyKey) {

            if (image_Play.color == colorHighlight) {
                SceneManager.LoadScene(1);
            }

            if (image_HighScores.color == colorHighlight) {
                print("SHOWING HIGHSCORES");
            }

        }
    }

    private void HighlightMenuButtons()
    {
        if (MastMovement.tilt < 5) {
            print("MINDRE 5");
            image_Play.color = colorHighlight;
            image_HighScores.color = colorNotPressed;
          
        }
        if (MastMovement.tilt > 10) {
            print("MER 10");
            image_Play.color = colorNotPressed;
            image_HighScores.color = colorHighlight;
           
        }
        
    }
}
