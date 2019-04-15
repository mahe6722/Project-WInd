using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuel : MonoBehaviour {

    public float playerFuel;
    public float fuelConsumption;
    public Slider fuelUI;

	// Use this for initialization
	void Start () {

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
        if (playerFuel <= 0) {
            print("Out of Fuel");
            playerFuel = 0;
        }

        //If Fuel is more than 100, make it 100.
        if (playerFuel > 100) {
            playerFuel = 100;
        }
    }
}
