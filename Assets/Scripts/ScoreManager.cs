using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance3;

    //현재 점수
    public Text scoreText;
    public int score = 0;

    //최고 점수
    public Text highScoreText;
    private int savedScore = 0;
    private string ScoreString = "High Score";

    //게임 오버 시 최종 점수
    public Text lastScoreText;
    private int lastScore = 0;

    void Awake()
    {
        if (!instance3) instance3 = this;

        savedScore = PlayerPrefs.GetInt(ScoreString, 0);
        highScoreText.text = "High Score : " + savedScore;
    }

    public void AddScore(int num)
    {
        //인게임 스코어 업데이트
        score += num;
        scoreText.text = "Score : " + score;
    }

    void Update()
    {
        if (score > savedScore)
        {
            PlayerPrefs.SetInt(ScoreString, score);
        }
    }

    //게임 클리어 시 저장된 점수 불러오기
    public void GameClearScore()
    {
        lastScore = score;
        lastScoreText.text = "Score : " + score;
        savedScore = PlayerPrefs.GetInt(ScoreString, 0);
        highScoreText.text = "High Score : " + savedScore;
    }

    public void RecordScore()
    {
        highScoreText.text = "High Score : " + savedScore;
    }
}
