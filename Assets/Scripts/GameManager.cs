using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //어디서나 접근할 수 있도록 static(정적)으로 선언

    public int pickUpStar = 0;      //별을 먹은 갯수
    public Transform starPos;       //별의 위치
    public GameObject starParticle; //별 파티클

    public GameObject starOneText;  //별1개 텍스트
    public GameObject starTwoText;  //별2개 텍스트
    public GameObject starThreeText;//별3개 텍스트
    public GameObject starFourText; //별4개 텍스트
    public GameObject starFiveText; //별5개 텍스트

    public bool isPause = false;
    public GameObject GameClear;
    public GameObject GameFail;
    public bool endGame = false;
    public GameObject volume;

    void Awake()
    {
        if (!instance) instance = this;
    }

    void Start()
    {
        starOneText.SetActive(false);
        starTwoText.SetActive(false);
        starThreeText.SetActive(false);
        starFourText.SetActive(false);
        starFiveText.SetActive(false);
        GameClear.SetActive(false);
        GameFail.SetActive(false);
        volume.SetActive(false);
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

    //일시정지
    public void GamePause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    
    //옵션 키 누른 후 볼륨조절
    public void VolumeControl()
    {
        SoundManager.instance5.buttonClick();
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
            volume.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            volume.SetActive(false);
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    //게임클리어 실패 시 전용 패널 활성화
    public void gameFail()
    {
        GamePause();
        GameFail.SetActive(true);
        endGame = true;
    }

    //게임 클리어시 전용 패널 활성화
    public void gameClear()
    {
        GamePause();
        GameClear.SetActive(true);
        endGame = true;
    }

    //게임 재시작
    public void GameRestart()
    {
        SoundManager.instance5.buttonClick();
        GamePause();
        GameFail.SetActive(false);
        GameClear.SetActive(false);
        endGame = false;
    }
} 
