using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour {

    public Text text_Restart;
    public Text text_MainMenu;

    public Color colorStart;
    public Color colorPressed;

    public MouseMovement mastMovement;

    void Start()
    {
       colorStart = text_MainMenu.color;
       colorPressed = text_Restart.color;
    
       
    }

    // Update is called once per frame
    void Update () {
		
        if(mastMovement.tilt > 0) {
            text_MainMenu.color = colorPressed;
            text_Restart.color = colorStart;
        }
        if(mastMovement.tilt < 0) {
            text_Restart.color = colorPressed;
            text_MainMenu.color = colorStart;
        }


	}
}
