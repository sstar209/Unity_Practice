using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroEnergy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 150;  //최대 체력
    private float curHp = 150;  //현재 체력
  
    //게임 시작 시 HP 꽉 채워서
    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    //플레이어와 몬스터 충돌 시 Hp는 10씩 감소
    void OnCollisionStay(Collision coll)
    {
        if(coll.collider.CompareTag("RABBIT"))
        {
            if(curHp > 0)
            {
                curHp -= 0.05f;
            }          
            else
            {
                curHp = 0;
            }

            HandleHp();
        }

        if (coll.collider.CompareTag("MUMMY"))
        {
            if (curHp > 0)
            {
                curHp -= 0.15f;
            }
            else
            {
                curHp = 0;
            }

            HandleHp();
        }

        if (coll.collider.CompareTag("BOSS"))
        {
            if (curHp > 0)
            {
                curHp -= 2.5f;
            }
            else
            {
                curHp = 0;
            }

            HandleHp();
        }
    }

    //선형보간 Mathf.Lerp(float A, float B, float t) -> A와 B사이의 t만큼의 값을 반환
    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
    }

    void Update()
    {
        //체력이 0이되면 게임오버
        if(curHp <= 0)
        {
            //ScoreManager.instance3.SaveTS();
            GameManager.instance.GameOver();
        }
    }
}
