using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour {

    public float Speed;
    public float clamp;
    public Vector2 startPosition;

    void Start()

    {
        startPosition = transform.position;
    }

    void Update ()
    {
        Vector2 offset = new Vector2(Time.time * Speed, clamp);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}
