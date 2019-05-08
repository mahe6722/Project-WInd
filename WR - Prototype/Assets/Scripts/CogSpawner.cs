using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpawner : MonoBehaviour
{
    public GameObject cogPrefab;

    GameObject player;

    public float respawnTime;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    void Start()
    {

        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        coroutine = cogWave();
        StartCoroutine(coroutine);
    }

    //void Update()
    //{
    //}

    private void spawnCog()
    {
        if (player.activeSelf)
        {
            GameObject cog = Instantiate(cogPrefab) as GameObject;
            cog.transform.position = new Vector2(Random.Range(-screenBounds.x + 0.2f, screenBounds.x - 0.2f), screenBounds.y * 2);
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator cogWave()
    {
        while (player.activeSelf)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCog();
        }
    }
}
