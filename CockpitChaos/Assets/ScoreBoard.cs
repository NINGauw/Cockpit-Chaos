using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }
    public void ScoreHit(int scorePoint){
        score+=scorePoint;
        scoreText.text = "Score: " + score.ToString();
    }
}
