using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemoverRockAndTire : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (gameObject.transform.childCount <= 6)
        {
            Destroy(gameObject);
        }
    }
}

