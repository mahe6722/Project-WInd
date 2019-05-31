using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactFuel : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cog")
        {
            //print("Cog spawned in obstacle - Removing cog");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SafetyCollider")
        {
            print("Hit Safety Collider");
            Destroy(other.gameObject);
        }
    }
}
