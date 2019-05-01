using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject projectilePlayer;
    public float timer_cooldown;
    public float cooldown_fireRate;
    public Transform playerTransform;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        timer_cooldown += Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(-playerTransform.forward, playerTransform.up);

		if (Input.GetKey(KeyCode.W) && timer_cooldown >= cooldown_fireRate) {
            Instantiate(projectilePlayer, transform.position, transform.rotation);
            timer_cooldown = 0f;
        }
	}
}
