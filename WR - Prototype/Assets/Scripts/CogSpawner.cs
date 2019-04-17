using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpawner : MonoBehaviour
{
    public GameObject cogPrefab;

    GameObject player;

    public float respawnTime;

    private Vector2 screenBounds;
    private Vector3 cogPos;

    private IEnumerator coroutine;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        coroutine = cogWave();
        StartCoroutine(coroutine);

        cogPos = cogPrefab.transform.position;

        player = GameObject.Find("Player");
    }

    //void Update()
    //{
    //}

    private void spawnCog()
    {
        if (player.activeSelf)
        {
            GameObject obstacle = Instantiate(cogPrefab) as GameObject;
            obstacle.transform.position = new Vector2(Random.Range(-screenBounds.x + 0.2f, screenBounds.x - 0.2f), screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator cogWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCog();
        }
    }
}
