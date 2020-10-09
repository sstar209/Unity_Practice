using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mummy_Energy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 10;
    private float curHp = 10;

    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    private void OnCollisionEnter(Collision coll2)
    {
        if (coll2.collider.CompareTag("MISSILE"))
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
    }

    void Update()
    {
        if(curHp <= 0)
        {
            ScoreManager.instance3.AddScore(5);

            Destroy(this.gameObject);
        }
    }
}
