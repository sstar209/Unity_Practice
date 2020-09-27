using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //어디서나 접근할 수 있도록 static(정적)으로 선언

    public Text scoreText;
    private int score = 0;

    void Awake()
    {
        if (!instance) instance = this;
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }
}
