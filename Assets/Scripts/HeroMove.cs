using UnityEngine;
using System;
using System.Collections;

public class HeroMove : MonoBehaviour
{
    float h, v;
    float speed = 3.0f;

    float jumpPower = 5.0f;
    bool jumping;

    public Transform missile_pos;
    public GameObject Hero_Missile;

    Animator mAvatar;
    Rigidbody rb;

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

        Jump();

        if(this.transform.position.y < -5.0f)
        {
            this.transform.position = new Vector3(0, 3.0f, 0);
        }
    }

    public void OnJumpBtnDown()
    {
        //플레이어가 지면에 닿아있을대만 점프할 수 있도록
        if(this.transform.position.y < 0.01f)
        {
            jumping = true;
        }
    }

    void Jump()
    {
        if (!jumping)
            return;

        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        jumping = false;
    }  
}
