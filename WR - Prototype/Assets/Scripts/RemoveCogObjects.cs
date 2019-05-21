using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCogObjects : MonoBehaviour
{
	void Update ()
    {
        if (gameObject.transform.childCount < 1)
        {
            Destroy(gameObject);
        }
	}
}
