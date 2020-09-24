using UnityEngine;
using System;
using System.Collections;

public class HeroMove : MonoBehaviour
{
    float h, v;
    float speed = 3.0f;

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
