using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private string scoreText;
    private int score;
    
    void Start()
    {
        scoreText = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = score.ToString();
        text.text = scoreText;
    }

    public void IncrementScore()
    {
        score++;
    }
}
