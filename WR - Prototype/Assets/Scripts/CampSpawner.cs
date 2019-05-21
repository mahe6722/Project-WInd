using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSpawner : MonoBehaviour
{
    public GameObject[] camps;

    //public GameObject campPrefabLeft;
    //public GameObject campPrefabRight;

    GameObject player;

    float respawnTime;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    int randomNumber;
    int counter = 0;

    int easyMode = 2;
    int mediumMode = 6;
    int hardMode = 8;

    int spawnLimit;

    void Start()
    {
        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = campWave();
        StartCoroutine(coroutine);

        spawnLimit = easyMode;
    }

    void Update()
    {
        if (counter > 1)
        {
            spawnLimit = mediumMode;
        }
        if (counter > 2)
        {
            spawnLimit = hardMode;
        }
        randomNumber = Random.Range(0, spawnLimit);
    }

    private void spawnCamps(int randomNumber)
    {

        if (randomNumber == 0) //Left
        {
            transform.position = new Vector2(-0.48f, screenBounds.y * 3);
        }
        if (randomNumber == 1) //Right
        {
            transform.position = new Vector2(0.48f, screenBounds.y * 3);
        }
        if (randomNumber == 2) //Right
        {
            transform.position = new Vector2(0, screenBounds.y * 4);
        }
        if (randomNumber == 3) //Right
        {
            transform.position = new Vector2(0, screenBounds.y * 4);
        }
        if (randomNumber == 4) //Right
        {
            transform.position = new Vector2(0, screenBounds.y * 4);
        }
        if (randomNumber == 5) //Right
        {
            transform.position = new Vector2(0, screenBounds.y * 4);
        }
        if (randomNumber == 6) //Right
        {
            transform.position = new Vector2(0.86f, screenBounds.y * 4);
        }
        if (randomNumber == 7) //Right
        {
            transform.position = new Vector2(0, screenBounds.y * 4);
        }
        if (randomNumber > 1 && randomNumber < 6) //Med
        {
            transform.position = new Vector2(0, screenBounds.y * 3);
        }
        print("Spawning Camp!" + randomNumber);
        Instantiate(camps[randomNumber], transform.position, Quaternion.identity);
        counter++;
    }

    IEnumerator campWave()
    {
        while (player.activeSelf)
        {
            respawnTime = Random.Range(5, 10);
            yield return new WaitForSeconds(respawnTime);
            spawnCamps(randomNumber);
        }
    }
}

