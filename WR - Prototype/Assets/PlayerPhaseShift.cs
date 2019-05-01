using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhaseShift : MonoBehaviour {

    BoxCollider2D[] playerBoxColliders;
    CircleCollider2D[] playerCircleColliders;
    public SpriteRenderer playerSprite;
    public SpriteRenderer dimensionSprite;

    public GameObject phasePortal;
    int portalEntrance = 0;
    int portalExit = 0;

    void Start()
    {
        playerBoxColliders = GameObject.Find("Player").GetComponents<BoxCollider2D>();
        playerCircleColliders = GameObject.Find("Player").GetComponents<CircleCollider2D>();

        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        dimensionSprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
            print("Entering Other Dimension");

            foreach(BoxCollider2D boxCollider in playerBoxColliders) {
                boxCollider.enabled = false;
            }
            foreach (CircleCollider2D circleCollider in playerCircleColliders) {
                circleCollider.enabled = false;
            }

            playerSprite.enabled = false;
            dimensionSprite.enabled = true;

            if(portalEntrance < 1) {
            Instantiate(phasePortal, transform.position, transform.rotation);
            portalEntrance++;
            portalExit = 0;
            }

        }
        else if (Input.GetKeyUp(KeyCode.W)) {
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
                Instantiate(phasePortal, transform.position, transform.rotation);
                portalExit++;
                portalEntrance = 0;
            }
        }
	}

   /* Looks like this.collider references the first of your colliders.You should use:

 BoxCollider[] myColliders = gameObject.GetComponents<BoxCollider>();
    to get an array of colliders attached and loop through the array.
    
 foreach(BoxCollider bc in myColliders) bc.enabled = false; */
}
