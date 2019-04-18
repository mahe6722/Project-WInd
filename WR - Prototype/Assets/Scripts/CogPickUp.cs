using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickUp : MonoBehaviour
{
    public int cogValue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Player picked up a cog!");
            Config.score += cogValue;
            Destroy(gameObject);
        }
    }
}
