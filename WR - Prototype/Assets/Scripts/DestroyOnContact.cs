using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Camp")
        {
            print("Obstacle spawned in the camp - Disabling");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "ExtraObstacle")
        {
            print("Obstacles collided - Removing extra");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Fuel")
        {
            print("Fuel spawned on obstacle - Disabling the obstacle");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Cog") 
        {
            print("Cog spawned on obstacle - Disabling the obstacle");
            Destroy(gameObject);
        }
    }
}
