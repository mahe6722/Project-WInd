using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour {

    public float respawnTime;
    public float timerRespawn;

    private float randomX;

    public GameObject fuel_small;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timerRespawn += Time.deltaTime;

        randomX = Random.Range(-4, 4);

        transform.position = new Vector2(randomX, 7); 


        if(timerRespawn >= respawnTime && player.activeInHierarchy == true) 
        {
            Instantiate(fuel_small, transform.position, transform.rotation);
            timerRespawn = 0;
        }
	}
}
