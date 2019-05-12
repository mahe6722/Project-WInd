using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuel : MonoBehaviour {

    public float playerFuel;
    public float fuelConsumption;

    public Image image_Fuel_Filled;
    public Image image_Fuel_Border; //Outline for Bar

    public GameObject warningFuelUI;

    float flashTimer;
    public float flashDuration;
    public float flashSpeed;
    Color fuelBarStartColor;

	
    void Start()
    {
        

    //    playerFuel = Config.fuel;
    }

	// Update is called once per frame
	void Update ()
    {
        FuelManager();

        //Set Fuel UI to value of playerFuel.
        image_Fuel_Filled.fillAmount = (playerFuel);
    }

    private void FuelManager()
    {
        //Only consume fuel if you have fuel.
        if (playerFuel > 0f) {
            playerFuel -= fuelConsumption * Time.deltaTime;
        }
        //Give console message, Out of Fuel and make sure fuel is exactly 0.
        if (playerFuel <= 0f) {
            print("Out of Fuel");
            playerFuel = 0;
        }

        //If Fuel is more than 1 make it 1.
        if (playerFuel > 1) {
            playerFuel = 1;
        }

        if (playerFuel < 0.4) {
            //TURN WARNING TRIANGLE ON.
            warningFuelUI.SetActive(true);

            flashTimer += Time.deltaTime;

            if (playerFuel <= 0.20) {
                flashSpeed = 8;

            } else if (playerFuel > 0.20) {
                flashSpeed = 4;
            }

            /*if (fuelBar.color == fuelBarStartColor) {

                fuelBar.color = new Color(0.7f, 0f, 0f, 1);

            }

            if (fuelBar.color != fuelBarStartColor && flashTimer >= flashDuration) {
                fuelBar.color = Color.Lerp(fuelBar.color, fuelBarStartColor, (flashSpeed * 4) * Time.deltaTime);

                if (fuelBar.color == fuelBarStartColor) {
                    flashTimer = 0f;
                }
            }*/
        }
        else if (playerFuel > 0.4) {
                    //fuelBar.color = fuelBarStartColor;
                    warningFuelUI.SetActive(false);
        }

    }
}
