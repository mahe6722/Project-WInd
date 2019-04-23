using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowMotion : MonoBehaviour {

    public float slowMotionFactor = 0.05f;

    public Image image_SlowMotionUI;

    bool slowmotionReady;
	
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

            if (Input.GetKeyDown(KeyCode.Space)) {
                image_SlowMotionUI.fillAmount -= 0.2f;
            }

            image_SlowMotionUI.fillAmount -= 1f * Time.deltaTime;
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        } else {
            if (image_SlowMotionUI.fillAmount < 1) {
                image_SlowMotionUI.fillAmount += 0.1f * Time.deltaTime;
            }

            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    private void SlowMotionCoolDown()
    {
        if (image_SlowMotionUI.fillAmount == 1) {
            slowmotionReady = true;

        } else if (Input.GetKeyUp(KeyCode.Space) && image_SlowMotionUI.fillAmount < 1) {
            slowmotionReady = false;
        }
        if (image_SlowMotionUI.fillAmount <= 0) {
            slowmotionReady = false;
        }
    }
}
