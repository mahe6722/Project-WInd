using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score;

	void Update ()
    {
        score = Config.score;
        scoreText.text = score.ToString();
	}
}
