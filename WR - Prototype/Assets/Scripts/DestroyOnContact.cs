using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    //void Start()
    //{
    //    print("Yo!");
    //}

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.name == "EnemyCampLeft(Clone)" || other.gameObject.name == "EnemyCampRight(Clone)")
        {
            print("Obstacle spawned in the camp - Disabling");
            Destroy(gameObject);
        }
    }
}
