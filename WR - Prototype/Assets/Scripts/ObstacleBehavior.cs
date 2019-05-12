using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    //public float speed;

    private Vector2 screenBounds;
    Config configScript;

    void Start()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        //speed = Config.speed;

        gameObject.transform.Translate(Vector2.down * configScript.speed * Time.smoothDeltaTime);
        if (transform.position.y < screenBounds.y * -3)
        {
            Destroy(this.gameObject);
        }
    }
}
