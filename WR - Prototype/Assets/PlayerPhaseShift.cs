using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhaseShift : MonoBehaviour {

    PlayerFuel playerFuelScript;
    float fuelConsumption;

    BoxCollider2D[] playerBoxColliders;
    CircleCollider2D[] playerCircleColliders;
    public SpriteRenderer playerSprite;
    public SpriteRenderer dimensionSprite;
    public GameObject playerTrailEffect;

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


    }

    // Update is called once per frame
    void Update () {

        timer_cooldown += Time.deltaTime;
        if (portalEntrance == 1) {
            timer_duration += Time.deltaTime;
            playerFuelScript.fuelConsumption = 0f;
        }
        if (portalExit == 1) {
            playerFuelScript.fuelConsumption = fuelConsumption;
        }

		if (Input.GetKey(KeyCode.W) && timer_cooldown > cooldown_phaseShift) {
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
        if (timer_duration > duration_phaseShift) {
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
	}
}
