using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    GameObject player;
    //Collider2D obstacleCollider;

    public float respawnTime;

    private Vector2 screenBounds;
    private Vector3 obstaclePos;

    bool isRunning = true;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(obstacleWave());

        obstaclePos = obstaclePrefab.transform.position;

        player = GameObject.Find("Player");  
    }

    void Update()
    {
        if (player != null)
        {
            StopCoroutine(obstacleWave());
            isRunning = false;
            print("Stopping?");
        }
    }

    private void spawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab) as GameObject;
        obstacle.transform.position = new Vector2(Random.Range(-screenBounds.x + 0.2f, screenBounds.x - 0.2f), screenBounds.y * 2);
    }

    IEnumerator obstacleWave()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }
}
