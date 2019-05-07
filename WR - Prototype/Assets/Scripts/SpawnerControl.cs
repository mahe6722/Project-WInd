using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    GameObject player;

    CampSpawner campSpawnerScript;
    ObstacleSpawner obstacleSpawnerScript;
    //FuelSpawner fuelSpawnerScript;
    //CogSpawner cogSpawnerScript;

    public float startSpawnObstacles;
    public float startSpawnCamps;

    private float timeCounter;

	void Start ()
    {
        player = GameObject.Find("Player");

        campSpawnerScript = GameObject.Find("CampSpawner").GetComponent<CampSpawner>();
        obstacleSpawnerScript = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        //fuelSpawnerScript = GameObject.Find("FuelSpawner").GetComponent<FuelSpawner>();
        //cogSpawnerScript = GameObject.Find("CogSpawner").GetComponent<CogSpawner>();
    }
	void Update ()
    {
        if (player.activeSelf)
        {
            timeCounter += Time.deltaTime;
        }
        

        if (timeCounter >= startSpawnObstacles && player.activeSelf == true)
        {
            obstacleSpawnerScript.enabled = true;
        }

        if (timeCounter >= startSpawnCamps && player.activeSelf == true)
        {
            campSpawnerScript.enabled = true;
        }
    }
}
