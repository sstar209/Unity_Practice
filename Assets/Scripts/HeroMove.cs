using UnityEngine;
using System;
using System.Collections;

public class HeroMove : MonoBehaviour
{
    bool jumping;
    float lastTime;

    float h, v;
    float speed = 3.0f;

    public Transform missile_pos;
    public GameObject Hero_Missile;

    Animator mAvatar;

    public void OnTouchValueChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    void Start()
    {
        mAvatar = GetComponent<Animator>();
    }

    public void OnMissileShootDown()
    {
        //미사일 발사시 발사 모션 진행
        mAvatar.SetTrigger("Fire");
    }

    public void OnMissileShootUp()
    {
        Instantiate(Hero_Missile, missile_pos.position, missile_pos.rotation);
    }

    void Update()
    {
        mAvatar.SetFloat("Speed", (h * h + v * v));

        if(h != 0f && v != 0f)
        {
            transform.Rotate(0, h, 0);
            transform.Translate(0, 0, v * speed * Time.deltaTime);
        }
    }
}
