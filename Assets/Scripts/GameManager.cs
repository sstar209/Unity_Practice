using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //어디서나 접근할 수 있도록 static(정적)으로 선언

    public Text scoreText;
    public int score = 0;           //적을 죽인 횟수
    public int pickUpStar = 0;      //별을 먹은 갯수
    public Transform starPos;       //별의 위치
    public GameObject starParticle; //별 파티클

    public GameObject starOneText;  //별1개 텍스트
    public GameObject starTwoText;  //별2개 텍스트
    public GameObject starThreeText;//별3개 텍스트
    public GameObject starFourText; //별4개 텍스트
    public GameObject starFiveText; //별5개 텍스트

    public delegate void OnPlay();
    public OnPlay onPlay;

    public bool isPlay = false;
    public GameObject playBtn;

    void Awake()
    {
        if (!instance) instance = this;

        starOneText.SetActive(false);
        starTwoText.SetActive(false);
        starThreeText.SetActive(false);
        starFourText.SetActive(false);
        starFiveText.SetActive(false);
    }

    //적을 죽일 수 +1
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;

        if( score > 3)
        {
            //GameOver();
        }
    }

    //별을 먹을 시 +1
    public void AddStar(int num2)
    {
        pickUpStar += num2;
    }

    //별을 먹을 시 파티클
    public void ParticlePlay()
    {
        GameObject imsy = Instantiate(starParticle, starPos.position, starPos.rotation);
        Destroy(imsy, 5.5f);
    }

    //첫번 쨰 별 문구
    public void StarOneText()
    {
        //오브젝트를 활성화하고 텍스트를 연다.
        starOneText.SetActive(true);

        //3초 후 오브젝트를 파괴하고 텍스트를 닫는다.
        Destroy(starOneText, 3.0f);
    }

    //두번 쨰 별 문구
    public void StarTwoText()
    {
        starTwoText.SetActive(true);

        Destroy(starTwoText, 3.0f);
    }

    //세번 쨰 별 문구
    public void StarThreeText()
    {
        starThreeText.SetActive(true);

        Destroy(starThreeText, 3.0f);
    }

    //네번 쨰 별 문구
    public void StarFourText()
    {
        starFourText.SetActive(true);

        Destroy(starFourText, 3.0f);
    }

    //다섯번 쨰 별 문구
    public void StarFiveText()
    {
        starFiveText.SetActive(true);

        Destroy(starFiveText, 3.0f);
    }

    //start버튼 클릭
    public void PlayBtnCilck()
    {
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke();
    }

    //게임 오버 시
    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke();
    }
} 
