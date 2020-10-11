using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEnergy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 5;
    private float curHp = 5;

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
        }
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
    }

    void Update()
    {
        HandleHp();

        if (curHp <= 0)
        {
            ScoreManager.instance3.AddScore(1);

            Destroy(this.gameObject);
        }
    }
}
