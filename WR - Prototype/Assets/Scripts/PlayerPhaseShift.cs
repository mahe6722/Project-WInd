using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhaseShift : MonoBehaviour {

    public Image image_PhaseShift_Ready;
    public Image image_PhaseShift_Activated;
    public Image image_PhaseShift_Cooldown;

    bool phaseShift_ready;
    bool phaseShift_activated;
    bool phaseShift_cooldown;

    public Text cooldown_timer_text;

    PlayerFuel playerFuelScript;
    float fuelConsumption;

    BoxCollider2D[] playerBoxColliders;
    CircleCollider2D[] playerCircleColliders;
    public SpriteRenderer playerSprite;
    public SpriteRenderer dimensionSprite;
    public Color startColor_dimensionSprite;

    public GameObject playerTrailEffect;
    public ParticleSystem engineParticles;
    public GameObject playerSmokeTrailEffect;

    public BoxCollider2D SafetyCollider_PhaseShift;
    public bool insideObstacle;
    

    public GameObject phasePortal;
    int portalEntrance = 0;
    public int portalExit = 0;

    public float timer_cooldown;
    public float timer_duration;
    public float cooldown_phaseShift;
    public float duration_phaseShift;

    void Start()
    {
        playerFuelScript = GameObject.Find("Player").GetComponent<PlayerFuel>();
        fuelConsumption = playerFuelScript.fuelConsumption;

        playerBoxColliders = GameObject.Find("Player").GetComponents<BoxCollider2D>();
        playerCircleColliders = GameObject.Find("Player").GetComponents<CircleCollider2D>();

        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        dimensionSprite = GetComponent<SpriteRenderer>();
        startColor_dimensionSprite = dimensionSprite.color;

        SafetyCollider_PhaseShift = GetComponent<BoxCollider2D>();

        engineParticles = GameObject.Find("newEngineTrail").GetComponent<ParticleSystem>();

        cooldown_timer_text = GameObject.Find("Cooldown_Timer").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update () {

        timer_cooldown += Time.deltaTime;
        

        if (dimensionSprite.enabled == true) {
            print("phasing");
            playerTrailEffect.SetActive(false);
            engineParticles.Play(false);
            playerSmokeTrailEffect.SetActive(false);
        }
        else if (playerFuelScript.playerFuel > 0.3) {
            playerTrailEffect.SetActive(true);
        }
        else if(playerFuelScript.playerFuel <= 0.3) {
            playerSmokeTrailEffect.SetActive(true);
        }


        //Ability Ready
        if (timer_cooldown > cooldown_phaseShift) {
            phaseShift_cooldown = false;
            phaseShift_ready = true;
            cooldown_timer_text.enabled = false;
        }
        else {
            phaseShift_ready = false;
        }

        if (portalEntrance == 1) {
            playerTrailEffect.SetActive(false);
            if(insideObstacle == false) {
            timer_duration += Time.deltaTime;
            }
            playerFuelScript.fuelConsumption = 0f;
        }
        if (portalExit == 1) {
            playerTrailEffect.SetActive(true);
            playerFuelScript.fuelConsumption = fuelConsumption;
        }

		if (Input.GetAxis("XboxTriggerLeft") > 0 && phaseShift_ready || Input.GetKey(KeyCode.Z) && phaseShift_ready){
            //Ability Activated
            phaseShift_activated = true;
           
            print("Entering Other Dimension");
            

            foreach(BoxCollider2D boxCollider in playerBoxColliders) {
                boxCollider.enabled = false;
            }
            foreach (CircleCollider2D circleCollider in playerCircleColliders) {
                circleCollider.enabled = false;
            }

            
            playerSprite.enabled = false;          
            dimensionSprite.enabled = true;
           
            if (portalEntrance < 1) {
            Instantiate(phasePortal, transform.position, transform.localRotation);
            portalEntrance++;
            portalExit = 0;
            }

        }
        if (timer_duration > duration_phaseShift && insideObstacle == false) {
            //Ability on Cooldown
            cooldown_timer_text.enabled = true;
            phaseShift_activated = false;
            phaseShift_cooldown = true;
            print("Returning From Dimension");

            foreach (BoxCollider2D boxCollider in playerBoxColliders) {
                boxCollider.enabled = true;
            }
            foreach (CircleCollider2D circleCollider in playerCircleColliders) {
                circleCollider.enabled = true;
            }

            playerSprite.enabled = true;
        
            dimensionSprite.enabled = false;

            if (portalExit < 1) {
                Instantiate(phasePortal, transform.position, transform.localRotation);
                portalExit++;
                portalEntrance = 0;
            }
            timer_cooldown = 0f;
            timer_duration = 0f;
        }

        //Phase UI
        if (phaseShift_ready) {
            image_PhaseShift_Ready.enabled = true;
        }
        if (phaseShift_activated) {
            image_PhaseShift_Ready.enabled = false;
        }
        if (phaseShift_cooldown) {
            image_PhaseShift_Ready.enabled = false;

            //PHASE TEXT COUNTDOWN           
            cooldown_timer_text.enabled = true;
           
            if (cooldown_phaseShift - timer_cooldown >= 0) {
                cooldown_timer_text.text = Mathf.Round(cooldown_phaseShift - timer_cooldown + 1).ToString();
                
            } else {
                cooldown_timer_text.enabled = false;
            }
            image_PhaseShift_Activated.fillAmount = timer_cooldown/cooldown_phaseShift;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fence" || collision.gameObject.tag == "Building" || collision.gameObject.tag == "Obstacle") {
            print("PHASE COLLISION");
            insideObstacle = true;
            timer_duration = 0f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fence" || collision.gameObject.tag == "Building" || collision.gameObject.tag == "Obstacle") {
            print("PHASE COLLISION STAY");
            insideObstacle = true;
            timer_duration = 0f;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fence" || collision.gameObject.tag == "Building" || collision.gameObject.tag == "Obstacle") {
            print("NO COLLISION");

            insideObstacle = false;
            timer_duration = 0f;
        }
    }
}
