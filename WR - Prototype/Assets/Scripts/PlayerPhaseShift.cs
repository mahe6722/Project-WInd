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

    PlayerFuel playerFuelScript;
    float fuelConsumption;

    BoxCollider2D[] playerBoxColliders;
    CircleCollider2D[] playerCircleColliders;
    public SpriteRenderer playerSprite;
    public SpriteRenderer dimensionSprite;
    public GameObject playerTrailEffect;

    public BoxCollider2D SafetyCollider_PhaseShift;
    public bool insideObstacle;
    

    public GameObject phasePortal;
    int portalEntrance = 0;
    int portalExit = 0;

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

        playerTrailEffect = GameObject.Find("Trail Effect");

        SafetyCollider_PhaseShift = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update () {

        timer_cooldown += Time.deltaTime;

        //Ability Ready
        if(timer_cooldown > cooldown_phaseShift) {
            phaseShift_cooldown = false;
            phaseShift_ready = true;
        }
        else {
            phaseShift_ready = false;
        }

        if (portalEntrance == 1) {
            if(insideObstacle == false) {
            timer_duration += Time.deltaTime;
            }
            playerFuelScript.fuelConsumption = 0f;
        }
        if (portalExit == 1) {
            playerFuelScript.fuelConsumption = fuelConsumption;
        }

		if (Input.GetKey(KeyCode.W) && phaseShift_ready) {
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
            playerTrailEffect.SetActive(false);
            dimensionSprite.enabled = true;

            if(portalEntrance < 1) {
            Instantiate(phasePortal, transform.position, transform.localRotation);
            portalEntrance++;
            portalExit = 0;
            }

        }
        if (timer_duration > duration_phaseShift && insideObstacle == false) {
            //Ability on Cooldown
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
            playerTrailEffect.SetActive(true);
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
