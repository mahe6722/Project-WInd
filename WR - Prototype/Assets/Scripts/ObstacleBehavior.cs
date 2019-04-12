using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float speed;

    //GameObject obstacle;

    private Vector2 screenBounds;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    void Update()
    {
        gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }
    }
}
