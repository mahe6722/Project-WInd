using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    PlayerRotation playerRotScript;

	void Start ()
    {
        player = GameObject.Find("Player");
        playerRotScript = player.GetComponent<PlayerRotation>();
	}

	void Update ()
    {
        gameObject.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y);

        if (player.transform.rotation.z < 0)
        {
            gameObject.transform.Translate(Vector2.right * (player.transform.rotation.z * -15) * Time.smoothDeltaTime);
        }
        if (player.transform.rotation.z > 0)
        {
            gameObject.transform.Translate(Vector2.left * (player.transform.rotation.z * 15) * Time.smoothDeltaTime);
        }
    }
}
