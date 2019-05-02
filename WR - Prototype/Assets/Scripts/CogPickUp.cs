using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickUp : MonoBehaviour
{
    public int cogValue;

    public Config configScript;
    public AudioSource cogSound;
    public SpriteRenderer cogSprite;
    public CircleCollider2D cogCollider;

    public GameObject particleEffect;
    public GameObject pickupEffect;

    void Start()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();
        cogSound = GetComponent<AudioSource>();
        cogSprite = GetComponent<SpriteRenderer>();
        cogCollider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cogSprite.enabled = false;
            cogCollider.enabled = false;
            cogSound.Play();
            Instantiate(pickupEffect, transform.position, transform.rotation);

 

            print("Player picked up a cog!");
            configScript.score += cogValue;

            if (!cogSound.isPlaying) {
                Destroy(gameObject);
                Destroy(particleEffect);
            }

            
        }
    }
}
