using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickUp : MonoBehaviour
{
    public float containerSize;
    PlayerFuel playerFuelScript;

    GameObject player;

    public AudioSource fuelSound;
    public SpriteRenderer fuelSprite;
    public BoxCollider2D fuelCollider;

    public GameObject pickupEffect;

    private void Start()
    {
        player = GameObject.Find("Player");

        if (player != null)
        {
            playerFuelScript = player.GetComponent<PlayerFuel>();
        }
        
        CheckSizeFuelContainer();

        fuelSound = GetComponent<AudioSource>();
        fuelSprite = GetComponent<SpriteRenderer>();
        fuelCollider = GetComponent<BoxCollider2D>();
    }

    //private void Update()
    //{
    //}

    private void CheckSizeFuelContainer()
    {
        //This is current size of fuel in camps, change if Fuel is made bigger. Use another "if" for the small size.
        if (transform.localScale.x >= 0.07 && transform.localScale.y >= 0.07) {
            containerSize = 25;
        }
        if (transform.localScale.x == 0.04f && transform.localScale.y == 0.04f) {
          containerSize = 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null && other.tag == "Player")
        {
            fuelSprite.enabled = false;
            fuelCollider.enabled = false;
            fuelSound.Play();
            Instantiate(pickupEffect, transform.position, transform.rotation);

            playerFuelScript.playerFuel += containerSize;

            print("Player picked up the fuel!");

            if (!fuelSound.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }   
}
