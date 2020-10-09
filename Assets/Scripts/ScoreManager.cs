using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance3;

    public Text scoreText;
    public int score = 0;

    public Text highScoreText;
    private int savedScore = 0;
    private string KeyString = "High Score";

    public Text lastText;
    private int lastScore = 0;

    void Awake()
    {
        if (!instance3) instance3 = this;

        savedScore = PlayerPrefs.GetInt(KeyString, 0);
        highScoreText.text = "High Score : " + savedScore;
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
        //lastText.text = "Score : " + score;
    }

    //점수가 갱신될때마다 highscore 점수 표시
    void Update()
    {
        //lastScore = score;

        if(score > savedScore)
        {
            PlayerPrefs.SetInt(KeyString, score);
        }
    }

    public void SaveTS()
    {
        PlayerPrefs.SetInt(KeyString, score);
    }

    public void LoadTS()
    {

    }
}
