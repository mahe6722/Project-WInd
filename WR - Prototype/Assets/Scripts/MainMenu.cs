using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mouseXposTracker;
    public GameObject highScoreTable;

    public Image image_Play;
    public Image image_HighScores;
    public Image image_Back;
    
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
                highScoreTable.SetActive(true);
                image_Back.enabled = true;
            }

            if (image_Back.color == colorHighlight) {
                highScoreTable.SetActive(false);
                image_Back.enabled = false;

                image_Play.enabled = true;
                image_HighScores.enabled = true;
            }

        }
    }

    private void HighlightMenuButtons()
    {
        if (mouseXposTracker.transform.position.x < 0) {
            print("MINDRE 5");
            image_Play.color = colorHighlight;
            image_HighScores.color = colorNotPressed;
          
        }
        if (mouseXposTracker.transform.position.x > 0) {
            print("MER 10");
            image_Play.color = colorNotPressed;
            image_HighScores.color = colorHighlight;
           
        }
        
    }
}
