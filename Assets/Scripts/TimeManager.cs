using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance4;

    public Text timerText;

    public float time;  //흐르는 총 시간
    public float min;   //시간 중 '분'
    public float sec;   //시간 중 '초'
    public float msec;  //시간 중 '밀리초'

    private string timeText1;
    private string timeText2;

    //최단 시간
    public Text highTimeText;
    private float savedTime = 55555f;
    private string TimeString = "High Time";

    //게임 오버 시 경과 시간
    public Text lastTimeText;
    private float lastTime = 0;

    private void Awake()
    {
        if (!instance4) instance4 = this;

        savedTime = PlayerPrefs.GetFloat(TimeString, 0);
        highTimeText.text = "High " + timeText1 + min + timeText2 + sec + " : " + msec;
    }

    private void Start()
    {
        time = 0;       //0초 부터 시작
        StartCoroutine("StopWatch");

        timeText1 = "Time 0";
        timeText2 = " : 0";
    }

    IEnumerator StopWatch()
    {
        while(true)
        {
                time += Time.deltaTime;

                //밀리초의 두자릿수만 나타내기 위해
                //100을 곱한 뒤 정수형으로 변환시켜준다.
                msec = (int)((time - (int)time) * 100);

                //초는 나머지 연산자(%) 60을 기준으로
                //마찬가지로 두자릿수만 나타내기 위해 같은 방법을
                sec = (int)(time % 60);

                //1분은 60초 이므로 60으로 나눠준다.
                //분도 정수형으로 변환
                min = (int)(time / 60 % 60);

                if (sec >= 10)
                {
                    timeText2 = " : ";
                }
                else
                {
                    timeText2 = " : 0";
                }

                if (min >= 10)
                {
                    timeText1 = "Time ";
                }
                else
                {
                    timeText1 = "Time 0";
                }

                //분,초,밀리초 자리배정
                timerText.text = timeText1 + min + timeText2 + sec + " : " + msec;

            yield return null;
        }
    }

    void Update()
    {
        if (time < savedTime)
        {
            PlayerPrefs.SetFloat(TimeString, time);
        }
    }

    //게임 클리어 시 저장된 시간 불러오기
    public void GameClearTime()
    {
        lastTime = time;
        lastTimeText.text = timeText1 + min + timeText2 + sec + " : " + msec;
        savedTime = PlayerPrefs.GetFloat(TimeString, 0);
        highTimeText.text = "High " + timeText1 + min + timeText2 + sec + " : " + msec;
    }
}
