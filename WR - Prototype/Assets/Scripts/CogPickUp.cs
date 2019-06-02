using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogPickUp : MonoBehaviour
{
    GameState gameStateScript;
    public int cogValue;

    public Config configScript;
    public AudioSource cogSound;
    public SpriteRenderer cogSprite;
    public CircleCollider2D cogCollider1;
    public CapsuleCollider2D cogCollider2;

    public GameObject particleEffect;
    public GameObject pickupEffect;
    public GameObject scoreFeedback;

    public Text scoreText;
    SpriteRenderer scoreFeedbackSprite;
    public Color scoreFeedbackColor;

    void Start()
    {
        gameStateScript = GameObject.Find("GameState").GetComponent<GameState>();
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();
        cogSound = GetComponent<AudioSource>();
        cogSprite = GetComponent<SpriteRenderer>();
        cogCollider1 = GetComponent<CircleCollider2D>();
        cogCollider2 = GetComponent<CapsuleCollider2D>();

        scoreFeedback = GameObject.Find("+Score Feedback");

        if (!gameStateScript.gameOver) {
        scoreFeedbackSprite = GameObject.Find("+Score Feedback").GetComponent<SpriteRenderer>();
        }

        if (!gameStateScript.gameOver) {
        scoreFeedbackColor = scoreFeedbackSprite.color;
        }

        if (!gameStateScript.gameOver) {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cogSprite.enabled = false;
            cogCollider1.enabled = false;
            cogCollider2.enabled = false;
            cogSound.Play();
            Instantiate(pickupEffect, transform.position, transform.rotation);

            Instantiate(scoreFeedback, transform.position, transform.rotation);
            scoreText.color = scoreFeedbackColor;

            print("Player picked up a cog!");
            configScript.score += cogValue;

            if (!cogSound.isPlaying) {
                Destroy(particleEffect);
                Destroy(gameObject);
                Destroy(scoreFeedback);
                
            }

            
        }
    }
}
