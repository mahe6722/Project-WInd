using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour {
  
    private Vector2 screenBounds;
    Config configScript;

    void Start()
    {
        configScript = GameObject.Find("DifficultySettings").GetComponent<Config>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        gameObject.transform.Translate(Vector2.down * configScript.speed * Time.deltaTime, Space.World);
        if (transform.position.y < screenBounds.y * -2) {
            Destroy(this.gameObject);
        }
    }
}
