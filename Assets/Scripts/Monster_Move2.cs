using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move2 : MonoBehaviour
{  
    public Transform heroTr;
    private WaitForSeconds wfs;
    public NavMeshAgent Monster_Agent;
    public Vector3 targetPosition;
    public Animator animator;
    public int monster_Energy = 5;

    void OnEnable()
    {
        StartCoroutine(CheckMonster());
        Debug.Log("OnEnable");
    }

    IEnumerator CheckMonster()
    {
        while(true)
        {
            yield return wfs;

            Monster_Agent.autoBraking = true;
            Monster_Agent.speed = 2.2f;
            ApproachTarget(heroTr.position);
        }
    }

    void Start()
    {
        Debug.Log("Start");
        var player = GameObject.FindGameObjectWithTag("STATUE");
        heroTr = player.GetComponent<Transform>();
        wfs = new WaitForSeconds(0.4f);
        Monster_Agent = GetComponent<NavMeshAgent>();
        Monster_Agent.autoBraking = false;
        animator = GetComponent<Animator>();
        Monster_Agent.speed = 1.3f;
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
        //몬스터가 미사일을 맞았을 시 체력이 1씩 감소
        if (coll.collider.CompareTag("MISSILE"))
        {
            monster_Energy -= 1;
        }
        else return;

        if(monster_Energy <= 0)
        {
            Destroy(this.gameObject);

            //적 죽일 시 1점씩 획득
            GameManager.instance.AddScore(1);
        }

    }

}

