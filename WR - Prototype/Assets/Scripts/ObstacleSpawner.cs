using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    GameObject player;

    public float respawnTime;

    float testSpeed;

    private Vector2 screenBounds;
    private Vector3 obstaclePos;

    private IEnumerator coroutine;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = obstacleWave();
        StartCoroutine(coroutine);

        obstaclePos = obstaclePrefab.transform.position;

        player = GameObject.Find("Player");
    }

    //void Update()
    //{
    //}

    private void spawnObstacle()
    {
        if (player.activeSelf)
        {
            GameObject obstacle = Instantiate(obstaclePrefab) as GameObject;
            obstacle.transform.position = new Vector2(Random.Range(-screenBounds.x + 0.2f, screenBounds.x - 0.2f), screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator obstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }
}