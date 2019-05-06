using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    IEnumerator coroutineSpeed;
    IEnumerator coroutineScore;

    public float speed = 3;
    public int score = 0;

    public float maxSpeed;
    public float speedIncrement;

    public float timeToIncreaseDifficulty = 5;

    float playerFuel;
    float oldSpeed;
    bool oneTime = false;
    bool wasOutOfFuel = false;

    PlayerFuel playerFuelScript;
    MouseMovement mouseMovementScript;
    GameObject player;

    void Start ()
    {
        coroutineSpeed = speedIncrease();
        StartCoroutine(coroutineSpeed);

        coroutineScore = scoreIncrease();
        StartCoroutine(coroutineScore);

        playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();

        mouseMovementScript = GameObject.Find("GameManager").GetComponent<MouseMovement>();

        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (playerFuelScript.playerFuel <= 0)
        {
            wasOutOfFuel = true;
            if (!oneTime)
            {
                oldSpeed = SaveSpeed(oldSpeed);
            }
            if (speed > 0)
            {
                speed -= 0.0075f;
            }          
            if (speed <= 0)
            {
                GameOver();
            }
        }

        if (playerFuelScript.playerFuel > 0 && wasOutOfFuel)
        {
            if (speed < oldSpeed)
            {
                speed += 0.05f;
            }
            oneTime = false;
        }

        if (!player.activeSelf)
        {
            speed = 0;
        }
    }

    private float SaveSpeed(float oldSpeed)
    {
        oldSpeed = speed;
        oneTime = true;
        return oldSpeed;
    }

    private void GameOver()
    {
        print("GameOver");
        mouseMovementScript.turnSpeed = 0f;
        player.SetActive(false);
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
        while (speed <= maxSpeed + 1)
        {
            yield return new WaitForSeconds(0.1f);
            score++;
            if (speed <= 0 || player.activeInHierarchy == false)
            {
                StopCoroutine(coroutineScore);
            }
        }
    }
}
