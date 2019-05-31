using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    GameObject player;

    float respawnTime;

    float testSpeed;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    int randomNumber;

    void Start()
    {
        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = obstacleWave();
        StartCoroutine(coroutine);
    }

    //void Update()
    //{
    //}

    private void spawnObstacles()
    {
        int randomNumber = Random.Range(0, obstacles.Length);
        transform.position = new Vector2(Random.Range(-screenBounds.x + 1, screenBounds.x - 1), screenBounds.y * 2);
        Instantiate(obstacles[randomNumber], transform.position, Quaternion.identity);
    }

    IEnumerator obstacleWave()
    {
        while (player.activeSelf)
        {
            respawnTime = Random.Range(1, 3);
            yield return new WaitForSeconds(respawnTime);
            spawnObstacles();
        }
    }
}