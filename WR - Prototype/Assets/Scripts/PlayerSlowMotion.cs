using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowMotion : MonoBehaviour {

    public float slowMotionFactor = 0.05f;

    public Image image_SlowMotionUI;
    public Image image_SlowMotionUIBorder;

    public MouseMovement mouseMovementScript;
    float normalTurnSpeed;
    float slowMotionTurnSpeed;
    

    bool slowmotionReady;

    private void Start()
    {
       normalTurnSpeed = mouseMovementScript.turnSpeed;
        slowMotionTurnSpeed = normalTurnSpeed + 0.3f;
        
    }

    // Update is called once per frame
    void Update ()
    {
        //Controls if Slow Motion will work or not
        SlowMotionCoolDown();

        //Controls how Slowmotion works.
        UsingSlowMotion();
    }

    private void UsingSlowMotion()
    {
        if (Input.GetKey(KeyCode.Space) && slowmotionReady) {

            //Fixed Slow-Motion cost
            if (Input.GetKeyDown(KeyCode.Space)) {
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
        if (Input.GetKeyUp(KeyCode.Space) && image_SlowMotionUI.fillAmount < 1 || image_SlowMotionUI.fillAmount <= 0) {
            slowmotionReady = false;

            //Changing UI color when Slow Motion on cooldown.
            colorChangeFill.a = 0.4f;
            colorChangeBorder.a = 0.4f;
            image_SlowMotionUI.color = colorChangeFill;
            image_SlowMotionUIBorder.color = colorChangeBorder;
        }
        
    }
}
