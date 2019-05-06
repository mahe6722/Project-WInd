using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactObstacle : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        //if (other.gameObject.tag == "Obstacle")
        //{
        //    print("Obstacle spawned in camp - Removing obstacle");
        //    Destroy(other.gameObject);
        //}
        if (other.gameObject.tag == "Fuel")
        {
            print("Fuel spawned in obstacle - Removing obstacle");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Cog")
        {
            print("Cog spawned in obstacle - Removing cog");
            Destroy(other.gameObject);
        }
    }
}
