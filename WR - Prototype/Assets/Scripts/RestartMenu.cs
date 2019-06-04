using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

    public GameObject mouseXposTracker;

    public Text text_yourScore;
   

    public Image image_Restart;
    public Image image_MainMenu;

    public Color colorHighlight;
    public Color colorNotPressed;

    public GameObject textRestartMenu;


    public Color colorStart_yourScore;
    public SpriteRenderer flashColorScore;

    public float flashTimer;
    public float flashSpeed;
    public float flashDuraction;

    public MouseMovement mastMovement;
    public Config configScript;

    public JoystickTest joystickScript;

    void Start()
    {

        colorHighlight = image_MainMenu.color;
        colorNotPressed = image_Restart.color;

        colorStart_yourScore = text_yourScore.color;

        joystickScript = GameObject.Find("MousePosLocator").GetComponent<JoystickTest>();
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
        if (Input.anyKey && textRestartMenu.activeInHierarchy == true) {

            //If RESTART is highlighted, Restart Game.
            if (image_Restart.color == colorHighlight) {

                SceneManager.LoadScene(1);
            }
            //If MAIN MENU is highlighted, Back to Main Menu.
            if (image_MainMenu.color == colorHighlight) {
                SceneManager.LoadScene("NewMainMenu");
            }

        }
    }

    private void HighlightMenuButtons()
    {
      

        if(Input.GetAxis("Vertical") > 0.0f) {
            image_MainMenu.color = colorHighlight;
            image_Restart.color = colorNotPressed;
        }
        if (mouseXposTracker.transform.position.x > 0 && joystickScript.joystickActive == false) {
            image_MainMenu.color = colorHighlight;
            image_Restart.color = colorNotPressed;
        }

        if (Input.GetAxis("Vertical") < 0.0f) {
            image_Restart.color = colorHighlight;
            image_MainMenu.color = colorNotPressed;
        }

        if (mouseXposTracker.transform.position.x < 0 && joystickScript.joystickActive == false) {
            image_Restart.color = colorHighlight;
            image_MainMenu.color = colorNotPressed;
        }

        

    }
}
