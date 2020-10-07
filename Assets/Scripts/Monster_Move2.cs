using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move2 : MonoBehaviour
{
    public Transform targetTr;
    private WaitForSeconds wfs;
    public NavMeshAgent Monster_Agent;
    public Vector3 targetPosition;
    public Animator animator;

    void OnEnable()
    {
        StartCoroutine(CheckMonster());
    }

    IEnumerator CheckMonster()
    {
        while (true)
        {
            yield return wfs;

            float distance = Vector3.Distance(this.transform.position, targetTr.position);

            if (distance <= 2.0)
            {
                //거리가 매우 가까운 상황
                Monster_Agent.speed = 0.1f;
                Monster_Agent.autoBraking = false;

            }
            else
            {
                Monster_Agent.autoBraking = true;
                Monster_Agent.speed = 2.2f;
                ApproachTarget(targetTr.position);
            }
        }
    }

    void Start()
    {
        if(GameManager.instance.isPlay)
        {
            var statue = GameObject.FindGameObjectWithTag("STATUE");
            targetTr = statue.GetComponent<Transform>();

            wfs = new WaitForSeconds(0.4f);
            Monster_Agent = GetComponent<NavMeshAgent>();
            Monster_Agent.autoBraking = false;
            animator = GetComponent<Animator>();
            Monster_Agent.speed = 2.2f;
        }
    }

    //플레이어의 위치를 매개변수로 받아 몬스터의 목표 위치를 플레이어 위치로 선정하는 함수
    void ApproachTarget(Vector3 pos)
    {
        if (Monster_Agent.isPathStale) return;
        Monster_Agent.destination = pos;
        Monster_Agent.isStopped = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        //몬스터가 미사일을 맞았을 시 추적타겟을 플레이어로 변경
        if (coll.collider.CompareTag("MISSILE"))
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            targetTr = player.GetComponent<Transform>();
        }
    }
}

