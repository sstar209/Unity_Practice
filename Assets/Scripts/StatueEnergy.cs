using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StatueEnergy : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 100;
    private float curHp = 100;

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
                curHp -= 0.05f;
            }
            else
            {
                curHp = 0;
                GameManager.instance.GameOver();
            }

        }

        HandleHp();
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 50);
    }
}
