using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") 
        {
            if(other.gameObject.tag == "Obstacle") {
                Destroy(other.gameObject);
                Destroy(gameObject);
                print("Projectile Hit Obstacle");
            }

            if (other.gameObject.tag == "Fence") {
                Destroy(other.gameObject);
                Destroy(gameObject);
                print("Projectile Hit Fence");
            }
        }
    }
}
