using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowMotion : MonoBehaviour {

    public float slowMotionFactor = 0.05f;

    public Image image_SlowMotionUI;
    public Image image_SlowMotionUIBorder; //Outline for Hourglass

    public Image overlay_SlowMotion;
    public Color flashColor;
    public Color startColor;
    public GameObject overlayBorder;

    public float flashTimer;
    public float flashDuration;
  

    public MouseMovement mouseMovementScript;
    float normalTurnSpeed;
    float slowMotionTurnSpeed;

    public Image SlowMotion_Overlay;

    bool slowmotionReady;

    private void Start()
    {
       normalTurnSpeed = mouseMovementScript.turnSpeed;
       slowMotionTurnSpeed = normalTurnSpeed + 0.3f;

        SlowMotion_Overlay = GameObject.Find("SlowMotion_Overlay").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Controls if Slow Motion will work or not
        SlowMotionCoolDown();

        //Controls how Slowmotion works.
        UsingSlowMotion();

        if(image_SlowMotionUI.fillAmount < 0.4f && slowmotionReady == true) {
            overlayBorder.SetActive(true);
            flashTimer += Time.deltaTime;
            print("Flashing Overlay Slow-Motion");
            if(overlay_SlowMotion.color == startColor) {

            overlay_SlowMotion.color = Color.Lerp(overlay_SlowMotion.color, flashColor, 80 * Time.deltaTime);

            }
            if (overlay_SlowMotion.color != startColor && flashTimer >= flashDuration){
                print("Turning Overlay Slow-Motion Back to transparent");
                overlay_SlowMotion.color = Color.Lerp(overlay_SlowMotion.color, startColor, 80 * Time.deltaTime);
                if (overlay_SlowMotion.color == startColor) {
                    flashTimer = 0f;
                }

            }


        } else {
            overlayBorder.SetActive(false);
            overlay_SlowMotion.color = overlay_SlowMotion.color = Color.Lerp(overlay_SlowMotion.color, startColor, 80 * Time.deltaTime);
        }

        /*if (takesDamage) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }*/
    }

    private void UsingSlowMotion()
    {
        if (Input.GetKey(KeyCode.P) && slowmotionReady || Input.GetButton("Xbox_RBumper") && slowmotionReady){

            SlowMotion_Overlay.enabled = true;
            //Fixed Slow-Motion cost
            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Xbox_RBumper")) {
                image_SlowMotionUI.fillAmount -= 0.2f;
            }
            //Depletes Slow Motion
            image_SlowMotionUI.fillAmount -= 1f * Time.deltaTime;

            //TRIGGERS SLOW_MOTION
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            mouseMovementScript.turnSpeed = slowMotionTurnSpeed;

            //Refill Slow Motion
        } else {
            if (image_SlowMotionUI.fillAmount < 1) {
                image_SlowMotionUI.fillAmount += 0.3f * Time.deltaTime;
            }

            //TURN SLOW_MOTION OFF!!
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            mouseMovementScript.turnSpeed = normalTurnSpeed;
            SlowMotion_Overlay.enabled = false;
        }
    }

    private void SlowMotionCoolDown()
    {
        var colorChangeFill = image_SlowMotionUI.color;
        var colorChangeBorder = image_SlowMotionUIBorder.color;

        if (image_SlowMotionUI.fillAmount == 1) {
            slowmotionReady = true;

            //Changing UI color when Slow Motion is Ready
            colorChangeFill.a = 1f;
            colorChangeBorder.a = 1f;
            image_SlowMotionUI.color = colorChangeFill;
            image_SlowMotionUIBorder.color = colorChangeBorder;

        }
        if (image_SlowMotionUI.fillAmount <= 0 || Input.GetKeyUp(KeyCode.P) && image_SlowMotionUI.fillAmount < 1 || Input.GetButtonUp("Xbox_RBumper") && image_SlowMotionUI.fillAmount < 1) {
            slowmotionReady = false; 

            //Changing UI color when Slow Motion on cooldown.
            colorChangeFill.a = 0.2f;
            colorChangeBorder.a = 0.2f;
            image_SlowMotionUI.color = colorChangeFill;
            image_SlowMotionUIBorder.color = colorChangeBorder;
        }
        
    }
}
