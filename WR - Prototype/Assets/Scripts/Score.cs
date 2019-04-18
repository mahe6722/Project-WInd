using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Config configScript;
    int score;

	void Update ()
    {
        score = configScript.score;
        scoreText.text = score.ToString();
	}
}
