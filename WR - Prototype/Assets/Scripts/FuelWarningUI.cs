using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelWarningUI : MonoBehaviour
{
    public float flashSpeed;
    public float flashTimer;
    public float flashInterval;

    Image image_WarningFuel;
    Color startColorWarningFuel;


    // Use this for initialization
    void Start()
    {
        image_WarningFuel = GetComponent<Image>();
        startColorWarningFuel = image_WarningFuel.color;
    }

    // Update is called once per frame
    void Update()

    {
        flashTimer += Time.deltaTime;

        if(image_WarningFuel.color == startColorWarningFuel && flashTimer >= flashInterval) {
            image_WarningFuel.color = Color.Lerp(startColorWarningFuel, new Color(0f, 0f, 0f, 0f), (flashSpeed) * Time.deltaTime);

            if (image_WarningFuel.color != startColorWarningFuel) {
                flashTimer = 0f;
            }
        }
        if (image_WarningFuel.color != startColorWarningFuel && flashTimer >= flashInterval) {

            image_WarningFuel.color = Color.Lerp(image_WarningFuel.color, startColorWarningFuel, flashSpeed * Time.deltaTime);

            if(image_WarningFuel.color == startColorWarningFuel) {
            flashTimer = 0;
            }
        }

    }

}
 
