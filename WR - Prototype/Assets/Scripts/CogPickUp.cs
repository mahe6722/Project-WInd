using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickUp : MonoBehaviour
{
    public int cogValue;

    public Config configScript;

    void Start()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Player picked up a cog!");
            configScript.score += cogValue;
            Destroy(gameObject);
        }
    }
}
