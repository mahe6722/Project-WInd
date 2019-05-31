using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireObstacleRemover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount <= 3)
        {
            Destroy(gameObject);
        }
    }
}
