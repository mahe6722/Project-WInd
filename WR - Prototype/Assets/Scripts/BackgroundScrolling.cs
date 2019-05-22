using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScrolling : MonoBehaviour
{
    private float length;
    private float startPos;
    private float distance;

    public GameObject cam;
    Config configScript;

    //public float speed;

    void Start ()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();

        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
	}
	void FixedUpdate ()
    {
        distance = gameObject.transform.position.y - startPos;
        gameObject.transform.Translate(Vector2.down * configScript.speed * Time.smoothDeltaTime);
        if (gameObject.transform.position.y <= -19)
        {
            //Mathf.Round(gameObject.transform.position.y + 57);
            gameObject.transform.Translate(new Vector3(0, Mathf.Round(gameObject.transform.position.y + 57), 0), Space.World);
            //startPos = startPos = transform.position.y;
        }
    }
}
