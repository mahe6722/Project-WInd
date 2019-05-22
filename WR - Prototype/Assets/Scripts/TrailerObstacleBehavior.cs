using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerObstacleBehavior : MonoBehaviour {

    //public float speed;

    private Vector2 screenBounds;
    Config configScript;

    void Start()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();

       
    }

    void FixedUpdate()
    {
        //speed = Config.speed;

        gameObject.transform.Translate(Vector2.down * configScript.speed * Time.smoothDeltaTime);
        
    }
}
