using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector2 startPosition;

    public Config configScript;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        scrollSpeed = configScript.speed;
        float newPosition = Mathf.Repeat(Time.time * configScript.speed /*scrollSpeed*/, tileSizeZ);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}