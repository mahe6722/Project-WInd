using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailManager : MonoBehaviour {

    ParticleSystem engineTrail;
    PlayerFuel playerFuelScript;

    ParticleSystem.ColorOverLifetimeModule colorModule;
    ParticleSystem.MinMaxGradient startColor_Engine;

    public float timer_EngineStutter;
    public float duration_EngineStutter;
	
	void Start () {

       engineTrail = GetComponent<ParticleSystem>();
       playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
       colorModule = engineTrail.colorOverLifetime;
       startColor_Engine = engineTrail.colorOverLifetime.color;
	}
	
	void Update () {

        timer_EngineStutter += Time.deltaTime;

        if (playerFuelScript.playerFuel < 0.35) {
            colorModule.color = Color.black;

            if(timer_EngineStutter > duration_EngineStutter && engineTrail.isPlaying) {
            engineTrail.Stop();
             timer_EngineStutter = 0;
            }

            if (!engineTrail.isPlaying) {
                engineTrail.Play();
            }
        }
        else if(Time.timeScale < 1) {
            colorModule.color = Color.cyan;
        }

        else if(playerFuelScript.playerFuel >= 0.35) {
            colorModule.color = startColor_Engine;
            if (!engineTrail.isPlaying) {
                engineTrail.Play();
            }
        }

	}
}
