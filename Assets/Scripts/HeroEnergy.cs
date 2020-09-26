using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroEnergy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 100;  //최대 체력
    private float curHp = 100;  //현재 체력
    
    //게임 시작 시 HP 꽉 채워서
    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    //플레이어와 몬스터 충돌 시 Hp는 10씩 감소
    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("RABBIT"))
        {
            if(curHp > 0)
            {
                curHp -= 10;
            }
            else
            {
                curHp = 0;
            }

            HandleHp();
        }
    }

    //Mathf.Lerp(float A, float B, float t) -> A와 B사이의 t만큼의 값을 반환
    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }
}
