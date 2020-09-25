using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Move : MonoBehaviour
{
    public float missile_speed = 100.0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * missile_speed);    
    }

    
    void Update()
    {
        //발사된 미사일이 2초 후에 제거되도록 하였다.
        Destroy(gameObject, 2f);
    }
}
