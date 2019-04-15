using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSpawner : MonoBehaviour
{
    public GameObject campPrefabLeft;
    public GameObject campPrefabRight;

    GameObject player;

    float respawnTime;
    int randomNumber;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    void Start()
    {
        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = campWave();
        StartCoroutine(coroutine);
    }

    //void Update()
    //{
    //}

    private void spawnCampLeft()
    {
        if (player.activeSelf)
        {
            GameObject campLeft = Instantiate(campPrefabLeft) as GameObject;
            campLeft.transform.position = new Vector2(-1.5f, screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    private void spawnCampRight()
    {
        if (player.activeSelf)
        {
            GameObject campRight = Instantiate(campPrefabRight) as GameObject;
            campRight.transform.position = new Vector2(1.5f, screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator campWave()
    {
        while (true)
        {
            respawnTime = Random.Range(3, 8);
            randomNumber = Random.Range(0, 2);

            yield return new WaitForSeconds(respawnTime);
            if (randomNumber == 0)
            {
                spawnCampLeft();
            }
            else if (randomNumber == 1)
            {
                spawnCampRight();
            }
        }
    }
}

