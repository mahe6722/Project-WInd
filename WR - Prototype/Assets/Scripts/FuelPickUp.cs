using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickUp : MonoBehaviour
{
    public float containerSize;
    PlayerFuel playerFuelScript;

    private void Start()
    {
        playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
        CheckSizeFuelContainer();
    }

    private void CheckSizeFuelContainer()
    {
        //This is current size of fuel in camps, change if Fuel is made bigger. Use another "if" for the small size.
        if (transform.localScale.x >= 0.2 && transform.localScale.y >= 0.2) {
            containerSize = 25;
        }
        if (transform.localScale.x >= 0.1 && transform.localScale.y >= 0.1) {
          containerSize = 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerFuelScript.playerFuel += containerSize;
           
            print("Player picked up the fuel!");
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
