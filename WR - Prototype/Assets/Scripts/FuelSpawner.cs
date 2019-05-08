using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject smallFuelPrefab;

    GameObject player;

    public float respawnTime;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

	void Start ()
    {
        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = fuelWave();
        StartCoroutine(coroutine);
    }
	
	//void Update ()
    //{
	//}

    private void spawnFuel()
    {
        if (player.activeSelf)
        {
            GameObject fuel = Instantiate(smallFuelPrefab) as GameObject;
            fuel.transform.position = new Vector2(Random.Range(-screenBounds.x + 0.2f, screenBounds.x - 0.2f), screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator fuelWave()
    {
        while (player.activeSelf)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnFuel();
        }
    }

}
