using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactCamp : MonoBehaviour
{
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            print("Obstacle spawned in camp - Removing obstacle");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Fuel")
        {
            print("Fuel spawned in camp - Removing fuel");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Cog")
        {
            print("Cog spawned in camp - Removing cog");
            Destroy(other.gameObject);
        }
    }
}
