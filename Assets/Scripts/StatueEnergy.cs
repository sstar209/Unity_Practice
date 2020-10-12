using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StatueEnergy : MonoBehaviour
{
    public static StatueEnergy instance8;

    [SerializeField]
    private Slider hpBar;

    private float maxHp = 5000;
    private float curHp = 5000;

    void Awake()
    {
        if (!instance8) instance8 = this;
    }

    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    void OnCollisionStay(Collision coll3)
    {
        if (coll3.collider.CompareTag("RABBIT"))
        {
            if (curHp > 0)
            {
                curHp -= 0.1f;
            }
        }

        if (coll3.collider.CompareTag("MUMMY"))
        {
            if(curHp > 0)
            {
                curHp -= 0.2f;
            }
        }

        if (curHp <= 0)
        {
            GameManager.instance.gameFail();
        }
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
    }

    public void StatueBossDamage()
    {
        curHp -= 15;
    }

    void Update()
    {
        HandleHp();
    }
}
