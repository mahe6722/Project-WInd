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
    int counter;

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
        if (counter > 5)
        {
            spawnLimit = mediumMode;
        }
        if (counter > 10)
        {
            spawnLimit = hardMode;
        }
    }

    private void spawnCamps()
    {
        int randomNumber = Random.Range(0, spawnLimit);
        if (randomNumber == 1) //Left
        {
            transform.position = new Vector2(-0.48f, screenBounds.y * 2);
        }
        else if (randomNumber == 2) //Right
        {
            transform.position = new Vector2(0.48f, screenBounds.y * 2);
        }
        Instantiate(camps[randomNumber], transform.position, Quaternion.identity);
        counter++;
    }

    IEnumerator campWave()
    {
        while (player.activeSelf)
        {
            respawnTime = Random.Range(5, 10);
            yield return new WaitForSeconds(respawnTime);
            spawnCamps();
        }
    }
}

