using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScrolling : MonoBehaviour
{
    private float length;
    private float startPos;

    public GameObject cam;
    Config configScript;

    int randomNumber;

    void Start ()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();

        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
	}
	void FixedUpdate ()
    {
        gameObject.transform.Translate(Vector2.down * configScript.speed * Time.smoothDeltaTime);
        if (gameObject.transform.position.y <= -10)
        {
            gameObject.transform.Translate(new Vector3(0, Mathf.Round(gameObject.transform.position.y + 40), 0), Space.World);
        }
    }
}
