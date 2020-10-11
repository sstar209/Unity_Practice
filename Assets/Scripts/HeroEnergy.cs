using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class HeroEnergy : MonoBehaviour
{
    public static HeroEnergy instance7;

    [SerializeField]
    private Slider hpBar;

    private float maxHp = 150;  //최대 체력
    private float curHp = 150;  //현재 체력

    void Awake()
    {
        if (!instance7) instance7 = this;
    }

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
                curHp -= 0.1f;
            }          
        }

        if (coll.collider.CompareTag("MUMMY"))
        {
            if (curHp > 0)
            {
                curHp -= 0.2f;
            }
        }

        if (curHp <= 0)
        {
            GameManager.instance.gameFail();
        }
    }

    //선형보간 Mathf.Lerp(float A, float B, float t) -> A와 B사이의 t만큼의 값을 반환
    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
    }

    public void PlayerBossDamage()
    {
        curHp -= 15;       
    }

    void Update()
    {
        HandleHp();
    }
}
