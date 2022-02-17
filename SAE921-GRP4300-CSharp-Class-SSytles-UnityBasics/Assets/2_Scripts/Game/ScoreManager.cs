using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private string scoreText;
    private int score;

    [SerializeField] private List<GameObject> drops;

    public List<GameObject> Drops
    {
        get { return drops; }
    }
    
    void Start()
    {
        scoreText = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = score.ToString();
        text.text = scoreText;

        for(int i = 0; i < drops.Count; i++)
        {
            if(drops[i] == null)
            {
                IncrementScore();
                drops.RemoveAt(i);
            }
        }

    }

    public void IncrementScore()
    {
        score++;
    }
}
