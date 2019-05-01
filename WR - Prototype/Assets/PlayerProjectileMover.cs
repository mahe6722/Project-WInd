using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMover : MonoBehaviour {

    public float projectileSpeed;
    Rigidbody2D projectileRigidBody;

    private void Awake()
    {
        projectileRigidBody = GetComponent<Rigidbody2D>();
     
    }
  
	// Update is called once per frame
	void Update () {

        transform.Translate(0, projectileSpeed * Time.deltaTime, 0, Space.Self);
       // projectileRigidBody.velocity = transform.up * projectileSpeed;
	}
}
