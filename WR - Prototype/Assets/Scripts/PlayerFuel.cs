using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuel : MonoBehaviour {

    public float playerFuel;
    public float fuelConsumption;
    public Slider fuelUI;
    public Image fuelBar;

    float flashTimer;
    public float flashDuration;
    public float flashSpeed;
    Color fuelBarStartColor;

	
    void Start()
    {
        fuelBar = GameObject.Find("FuelBar").GetComponent<Image>();
        fuelBarStartColor = fuelBar.color;

    //    playerFuel = Config.fuel;
    }

	// Update is called once per frame
	void Update ()
    {
        FuelManager();

        //Set Fuel UI to value of playerFuel.
        fuelUI.value = playerFuel;
    }

    private void FuelManager()
    {
        //Only consume fuel if you have fuel.
        if (playerFuel > 0) {
            playerFuel -= fuelConsumption * Time.deltaTime;
        }
        //Give console message, Out of Fuel and make sure fuel is exactly 0.
        if (playerFuel <= 0)
        {
            //print("Out of Fuel");
            playerFuel = 0;
        }

        //If Fuel is more than 100, make it 100.
        if (playerFuel > 100) {
            playerFuel = 100;
        }

        if (playerFuel < 40) {
            flashTimer += Time.deltaTime;
            if(playerFuel <= 20) {
                flashSpeed = 8;
            }
            else if (playerFuel > 20) {
                flashSpeed = 4;
            }

            if (fuelBar.color == fuelBarStartColor) {

                fuelBar.color = new Color(0.45f, 0f, 0f, 1);

            }

            if (fuelBar.color != fuelBarStartColor && flashTimer >= flashDuration) {
                fuelBar.color = Color.Lerp(fuelBar.color, fuelBarStartColor, (flashSpeed * 4) * Time.deltaTime);

                if (fuelBar.color == fuelBarStartColor) {
                    flashTimer = 0f;
                }
            }
        }
        else if (playerFuel > 40) {
            fuelBar.color = fuelBarStartColor;
        }
        
    }
}
