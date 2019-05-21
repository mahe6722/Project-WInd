using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailManager : MonoBehaviour {

    public GameObject smokeEngineParticle;
    public GameObject engineParticle;
    ParticleSystem engineTrail;
    ParticleSystem smokeTrail;
    PlayerFuel playerFuelScript;

    ParticleSystem.ColorOverLifetimeModule colorModule;
    ParticleSystem.MinMaxGradient startColor_Engine;

    public float timer_EngineStutter;
    public float duration_EngineStutter;
	
	void Start () {

       engineTrail = engineParticle.GetComponent<ParticleSystem>();
        smokeTrail = smokeEngineParticle.GetComponent<ParticleSystem>();
       playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
       colorModule = engineTrail.colorOverLifetime;
       startColor_Engine = engineTrail.colorOverLifetime.color;
	}
	
	void Update () {

        timer_EngineStutter += Time.deltaTime;

        if (playerFuelScript.playerFuel < 0.3) {
            smokeEngineParticle.SetActive(true);
            engineParticle.SetActive(false);

            if(timer_EngineStutter > duration_EngineStutter && smokeTrail.isPlaying) {
            smokeTrail.Stop();
             timer_EngineStutter = 0;
            }

            if (!smokeTrail.isPlaying) {
                smokeTrail.Play();
            }
        }
        else if(Time.timeScale < 1) {
            colorModule.color = Color.cyan;
        }

        else if(playerFuelScript.playerFuel >= 0.35) {
            colorModule.color = startColor_Engine;
            smokeEngineParticle.SetActive(false);
            engineParticle.SetActive(true);
            if (!engineTrail.isPlaying) {
                engineTrail.Play();
            }
        }

	}
}
