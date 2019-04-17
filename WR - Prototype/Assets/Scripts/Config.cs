using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    IEnumerator coroutine;

    public static float speed = 3;

    public float maxSpeed;
    public float speedIncrement;

    public float timeToIncreaseDifficulty = 5;

    float playerFuel;

    PlayerFuel playerFuelScript;
    MouseMovement mouseMovementScript;

    void Start ()
    {
        coroutine = speedIncrease();
        StartCoroutine(coroutine);

        playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
        //playerFuel = playerFuelScript.playerFuel;

        mouseMovementScript = GameObject.Find("Player").GetComponent<MouseMovement>();
    }

    void Update()
    {
        if (playerFuelScript.playerFuel <= 0)
        {
            speed -= 0.03f;
            if (speed <= 0)
            {
                print("GameOver");
                mouseMovementScript.enabled = false;
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator speedIncrease()
    {
        while (speed <= maxSpeed)
        {
            //If speed is less that speed cap, increase it every 5 seconds
            if (speed <= maxSpeed)
            {
                yield return new WaitForSeconds(timeToIncreaseDifficulty);
                speed += speedIncrement;
            }
            //Else set the speed to speed cap and stop increasing the speed
            else
            {
                speed = maxSpeed;
                StopCoroutine(coroutine);
            }
        }
    }
}
