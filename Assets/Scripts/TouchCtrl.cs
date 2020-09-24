using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TouchCtrl : MonoBehaviour
{
    //TouchCtrl 오브젝트의 RectTransform 객체 선언
    RectTransform touchCtrl;
    private int touchID = -1;

    //입력 시작 위치 초기화
    private Vector2 startPos = Vector2.zero;

    //컨트롤러가 움직일 수 있는 반지름
    //값이 커질수록 드래그할 수 있는 반경이 커짐
    public float dragRadius = 50f;

    private bool btnPressed = false;

    void Start()
    {
        //TouchCtrl 오브젝트 RectTransform 컴포넌트 가져오기
        touchCtrl = GetComponent<RectTransform>();

        //컨트롤러의 처음 위치
        startPos = touchCtrl.position;
    }

    //Event Trigger에서 처리 (터치가 될 경우 실행)
    public void TouchDown()
    {
        btnPressed = true;
    }

    public void TouchUp()
    {
        btnPressed = false;

        //터치한 손을 놓으면 컨트롤러를 원래 지점으로 복귀
        SendInputValue(startPos);
    }

    void FixedUpdate()
    {
        HandleTouchPhase();

        //전처리기를 사용하여 모바일이 아닌 경우 (Unity Editor, 웹플레이)에서는 마우스로 입력받기 설정
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER || UNITY_STANDALONE_OSX

        SendInputValue(Input.mousePosition);

#endif

    }

    void HandleTouchPhase()
    {
        int i = 0;

        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                i++;

                //현재 터치한 x,y 좌표 구하기
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        if (touch.position.x <= (startPos.x + dragRadius))
                        {
                            touchID = i;
                        }
                        break;
                    case TouchPhase.Moved:
                        if(touchID == i)
                        {
                            SendInputValue(touchPos);
                        }
                        break;
                    case TouchPhase.Stationary:
                        if(touchID == i)
                        {
                            SendInputValue(touchPos);
                        }
                        break;
                    case TouchPhase.Ended:
                        if(touchID == i)
                        {
                            touchID = -1;
                        }
                        break;
                }
            }
        }
    }

    void SendInputValue(Vector2 inputPos)
    {
        if(btnPressed)
        {
            //컨트롤러의 기준 좌표로부터 입력받은 좌표 사이의 거리 구하기
            Vector2 gabPos = (inputPos - startPos);

            //입력 지점이 기준 좌표로부터 일정 거리 안에 있으면
            if(gabPos.sqrMagnitude <= dragRadius * dragRadius)
            {
                //현재 터치 좌표로 방향키 이동하기
                touchCtrl.position = inputPos;
            }

            //입력 지점이 일정한 기준 좌표보다 크다면
            else 
            {
                //벡터 크기를 정규화하기
                gabPos.Normalize();

                touchCtrl.position = startPos + gabPos * dragRadius;
            }
        }

        else
        {
            //터치한 손을 놓으면 컨트롤러를 초기위치로 설정
            touchCtrl.position = startPos;
        }

        Vector2 touchPosXY = new Vector3(touchCtrl.position.x, touchCtrl.position.y);
        Debug.Log(touchCtrl.position.x);
        Debug.Log(touchCtrl.position.y);

        Vector2 diff = touchPosXY - startPos;
        Vector2 normDiff = new Vector2(diff.x / dragRadius, diff.y / dragRadius);
       
    }
}
