using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosXLocator : MonoBehaviour
{
    private Vector2 direction;
	void Start ()
    {
        gameObject.transform.position = new Vector3(2, 5.5f, -10);
	}
	void Update ()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      

        direction = (mousePos - gameObject.transform.position).normalized;

        gameObject.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y);

        if (gameObject.transform.position.x >= -5 && gameObject.transform.position.x <= 5)
        {
            gameObject.transform.Translate(new Vector2(direction.x * Time.smoothDeltaTime * 100, 0));
        }
    }
}
