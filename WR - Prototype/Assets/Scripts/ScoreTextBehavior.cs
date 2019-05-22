using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehavior : MonoBehaviour {

    Text scoreText;
    Color startColor;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        startColor = scoreText.color;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(scoreText.color != startColor) {
            scoreText.color = Color.Lerp(scoreText.color, startColor, 3.5f * Time.deltaTime);
        }

	}
}
