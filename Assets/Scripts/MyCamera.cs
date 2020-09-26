using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    Vector3 offset;

    public float cameraSpeed;   //카메라 이동 속도
    public Transform target;    //플레이어 오브젝트의 좌표값 저장

    void Start()
    {
        //카메라와 플레이어 사이의 거리 구함
        offset = transform.position - target.position;
    }
   
    void Update()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        Vector3 pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);

        transform.position = pos;
    }
}
