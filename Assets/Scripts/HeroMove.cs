using UnityEngine;
using System;
using System.Collections;

public class HeroMove : MonoBehaviour
{
    float h, v;
    float speed = 5.0f;

    float jumpPower = 5.0f;
    bool jumping;

    public Transform missile_pos;
    public GameObject Hero_Missile;
    public GameObject missile_effect;

    Animator mAvatar;
    Rigidbody rb;
    public AudioSource playerSound;

    public AudioClip shootSound;
    public AudioClip jumpSound;

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
        if(GameManager.instance.isPlay)
        {
            //미사일 발사시 발사 모션 진행
            mAvatar.SetTrigger("Fire");

            //미사일 파티클 0.5초 후 삭제되도록
            GameObject imsy = Instantiate(missile_effect, missile_pos.position, missile_pos.rotation);
            Destroy(imsy, 0.5f);

            //공격 시 효과음 재생
            playerSound.PlayOneShot(shootSound);
        }
    }

    public void OnMissileShootUp()
    {
        if(GameManager.instance.isPlay)
        {
            Instantiate(Hero_Missile, missile_pos.position, missile_pos.rotation);
        }
    }

    void Update()
    {
        if(GameManager.instance.isPlay)
        {
            mAvatar.SetFloat("Speed", (h * h + v * v));

            if (h != 0f && v != 0f)
            {
                transform.Rotate(0, h, 0);
                transform.Translate(0, 0, v * speed * Time.deltaTime);
            }

            Jump();

            if (this.transform.position.y < -5.0f)
            {
                this.transform.position = new Vector3(0, 3.0f, 0);
            }
        }
    }

    public void OnJumpBtnDown()
    {
        if(GameManager.instance.isPlay)
        {
            //플레이어가 지면에 닿아있을대만 점프할 수 있도록
            if (this.transform.position.y < 0.01f)
            {
                jumping = true;
            }

            playerSound.PlayOneShot(jumpSound);
        }
    }

    void Jump()
    {
        if (!jumping)
            return;

        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        jumping = false;
    }

    //적과 충돌 시 위로 붕뜨는 현상 방지

    void OnCollisionEnter(Collision coll1)
    {
        if(coll1.collider.CompareTag("RABBIT"))
        {
            this.rb.mass += 2;
        }
    }

    void OnCollisionExit(Collision coll2)
    {
        if (coll2.collider.CompareTag("RABBIT"))
        {
            this.rb.mass = 1;
        }
    }
}
