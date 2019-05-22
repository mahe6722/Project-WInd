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
    public CircleCollider2D cogCollider;

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
        cogCollider = GetComponent<CircleCollider2D>();

        scoreFeedback = GameObject.Find("+Score Feedback");
        scoreFeedbackSprite = GameObject.Find("+Score Feedback").GetComponent<SpriteRenderer>();
        scoreFeedbackColor = scoreFeedbackSprite.color;

        if (!gameStateScript.gameOver) {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cogSprite.enabled = false;
            cogCollider.enabled = false;
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
