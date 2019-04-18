using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    IEnumerator coroutineSpeed;
    IEnumerator coroutineScore;

    public static float speed = 3;
    public static int score = 0;

    public float maxSpeed;
    public float speedIncrement;

    public float timeToIncreaseDifficulty = 5;

    float playerFuel;

    PlayerFuel playerFuelScript;
    MouseMovement mouseMovementScript;

    void Start ()
    {
        coroutineSpeed = speedIncrease();
        StartCoroutine(coroutineSpeed);

        coroutineScore = scoreIncrease();
        StartCoroutine(coroutineScore);

        playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();

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
                //Time.timeScale = 0;
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
                StopCoroutine(coroutineSpeed);
            }
        }
    }

    IEnumerator scoreIncrease()
    {
        //Increases score by 1 every second
        while (speed <= maxSpeed)
        {
            yield return new WaitForSeconds(1);
            score++;
            if (speed <= 0)
            {
                StopCoroutine(coroutineScore);
            }
        }
    }
}
