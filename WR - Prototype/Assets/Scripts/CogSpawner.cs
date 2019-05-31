using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpawner : MonoBehaviour

{
    GameState gameStateScript;

    public GameObject[] cogs;

    GameObject player;

    public float respawnTime;

    private Vector2 screenBounds;

    private IEnumerator coroutine;

    int randomNumber;

    void Start()
    {
        gameStateScript = GameObject.Find("GameState").GetComponent<GameState>();
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
        transform.position = new Vector2(Random.Range(-screenBounds.x + 1.5f, screenBounds.x - 1.5f), screenBounds.y * 3);
        Instantiate(cogs[randomNumber], transform.position, Quaternion.identity);
    }

    IEnumerator cogWave()
    {
        while (player.activeSelf && !gameStateScript.gameOver)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCogs(randomNumber);
        }
    }
}
