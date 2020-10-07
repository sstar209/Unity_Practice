using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText;

    public float time;  //흐르는 총 시간
    public float min;   //시간 중 '분'
    public float sec;   //시간 중 '초'
    public float msec;  //시간 중 '밀리초'

    private string timeText1;
    private string timeText2;

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
}
