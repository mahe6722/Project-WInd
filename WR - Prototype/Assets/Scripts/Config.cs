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

	void Start ()
    {
        coroutine = speedIncrease();
        StartCoroutine(coroutine);
	}
    //void Update ()
    //{
    //}

    IEnumerator speedIncrease()
    {
        while (true)
        {
            if (speed <= maxSpeed)
            {
                yield return new WaitForSeconds(timeToIncreaseDifficulty);
                speed += speedIncrement;
            }
            else
            {
                speed = maxSpeed;
                StopCoroutine(coroutine);
            }
        }
    }
}
