﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    GameObject player;
    public GameObject ExplosionParticle;
    public Screenshake cameraShake;

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
            if (other.tag == "Fence" || other.tag == "Building")
            {
                Instantiate(ExplosionParticle, transform.position, transform.rotation);
                StartCoroutine(cameraShake.Shake(3f, 2f));
                print("Player hit a fence or a bunker");
                player.SetActive(false);
            }
            if (other.tag == "Obstacle")
            {
                Instantiate(ExplosionParticle, transform.position, transform.rotation);
                StartCoroutine(cameraShake.Shake(3f, 2f));
                print("Player hit an obstacle");
                player.SetActive(false);
            }
        }
    }
}
