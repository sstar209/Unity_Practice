using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroMove : MonoBehaviour
{
    float h, v;
    public float speed = 5.0f;

    public byte colorNum = 255;             //부스터 버튼 색상 조절
    private bool colorCha;                  //부스터 쿨타임

    public Transform missile_pos;           //미사일의 위치
    public GameObject Hero_Missile;         //미사일 오브젝트
    public GameObject missile_effect;       //미사일 파티클

    Animator mAvatar;
    Rigidbody rb;

    public Image btn;

    public void OnTouchValueChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    void Start()
    {
        mAvatar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMissileShootDown()
    {
        //미사일 발사시 발사 모션 진행
        mAvatar.SetTrigger("Fire");

        //미사일 파티클 0.5초 후 삭제되도록
        GameObject imsy = Instantiate(missile_effect, missile_pos.position, missile_pos.rotation);
        Destroy(imsy, 0.5f);

        //공격 시 효과음 재생
        SoundManager.instance5.playerShoot();       
    }

    public void OnMissileShootUp()
    {
        Instantiate(Hero_Missile, missile_pos.position, missile_pos.rotation);        
    }

    void Update()
    {
        mAvatar.SetFloat("Speed", (h * h + v * v));

        if (h != 0f && v != 0f)
        {
            transform.Rotate(0, h, 0);
            transform.Translate(0, 0, v * speed * Time.deltaTime);
        }

        if (this.transform.position.y < -5.0f)
        {
            this.transform.position = new Vector3(0, 3.0f, 0);
        }

        //부스터 발동 시 기본 속도가 될때까지 점점 스피드 감소
        if (speed > 5)
        {
            speed -= 1.5f * Time.deltaTime;
        }

        //쿨타임이 초기화되면 버튼의 색이 원래대로 돌아온다.
        if(colorNum == 255)
        {
            btn.color = new Color32(255, 255, 255, 255);
        }

        if (colorCha)
        {
            colorCha = false;
            StartCoroutine("Change");
        }       
    }

    //colorNum == 쿨타임!

    IEnumerator Change()
    {
        yield return new WaitForSeconds(0.1f);

        colorNum++;

        if(colorNum < 255)
        StartCoroutine("Change");
    }

    public void OnBoosterBtnDown()
    {
        if(speed < 5.1f && colorNum == 255)
        {
            colorNum = 125;

            colorCha = true;

            speed = 12.5f;
            SoundManager.instance5.playerBoost();

            btn.color = new Color32(colorNum, colorNum, colorNum, 255);
        }
    }   
}
