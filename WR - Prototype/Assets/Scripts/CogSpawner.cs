using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpawner : MonoBehaviour
{
    public GameObject[] cogs;

    GameObject player;

    public float respawnTime;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    int randomNumber;

    void Start()
    {
        player = GameObject.Find("Player");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        coroutine = cogWave();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        randomNumber = Random.Range(0, cogs.Length);
    }

    private void spawnCogs(int randomNumber)
    {
        if (randomNumber == 0)
        {
            transform.position = new Vector2(Random.Range(-screenBounds.x - 4, screenBounds.x - 7), screenBounds.y * 3);
            Instantiate(cogs[randomNumber], transform.position, Quaternion.identity);
        }
        if (randomNumber == 1)
        {
            transform.position = new Vector2(Random.Range(-screenBounds.x + 3, screenBounds.x - 5), screenBounds.y * 3);
            Instantiate(cogs[randomNumber], transform.position, Quaternion.identity);
        }
        if (randomNumber == 2)
        {
            transform.position = new Vector2(Random.Range(-screenBounds.x + 3, screenBounds.x - 5), screenBounds.y * 3);
            Instantiate(cogs[randomNumber], transform.position, Quaternion.identity);
        }
        if (randomNumber == 3)
        {
            transform.position = new Vector2(Random.Range(-screenBounds.x + 3, screenBounds.x - 5), screenBounds.y * 3);
            Instantiate(cogs[randomNumber], transform.position, Quaternion.identity);
        }
    }

    IEnumerator cogWave()
    {
        while (player.activeSelf)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCogs(randomNumber);
        }
    }
}
