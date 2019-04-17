using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    //void Update()
    //{
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null)
        {
            if (other.tag == "Fence" || other.tag == "Bunker")
            {
                print("Player hit a fence or a bunker");
                player.SetActive(false);
            }
            if (other.tag == "Obstacle")
            {
                print("Player hit an obstacle");
                player.SetActive(false);
            }
        }
    }
}
