using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailManager : MonoBehaviour {

    ParticleSystem engineTrail;
    PlayerFuel playerFuelScript;

    ParticleSystem.ColorOverLifetimeModule colorModule;
    ParticleSystem.MinMaxGradient startColor_Engine;
	
	void Start () {

       engineTrail = GetComponent<ParticleSystem>();
       playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
       colorModule = engineTrail.colorOverLifetime;
       startColor_Engine = engineTrail.colorOverLifetime.color;
	}
	
	void Update () {
		
        if (playerFuelScript.playerFuel < 30) {
            colorModule.color = Color.black;
        }
        else if(Time.timeScale < 1) {
            colorModule.color = Color.cyan;
        }

        else if(playerFuelScript.playerFuel >= 30) {
            colorModule.color = startColor_Engine;
        }

	}
}
