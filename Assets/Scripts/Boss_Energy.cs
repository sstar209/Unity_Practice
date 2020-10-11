using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Energy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 77;
    private float curHp = 77;

    void Start()
    {
        //하이어라키에 있는 보스전용 hpbar를 가져온다
        var bossHpBar = GameObject.Find("BossHpBar");
        hpBar = bossHpBar.GetComponent<Slider>();

        hpBar.value = (float)curHp / (float)maxHp;    
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("MISSILE"))
        {
            if (curHp > 0)
            {
                curHp -= 1;
            }
            else
            {
                curHp = 0;
            }

            HandleHp();
        }
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
        BossDie();
    }


    void BossDie()
    {
        if (curHp <= 0)
        {
            TimeManager.instance4.GameClearTime();
            ScoreManager.instance3.GameClearScore();
            GameManager.instance.gameClear();
        }
    }
}
