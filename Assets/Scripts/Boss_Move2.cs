using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss_Move2 : MonoBehaviour
{
    private NavMeshAgent nv;
    public Transform targetTr;
    public int boss_Energy = 50;

    private WaitForSeconds wfs;

    public bool isPatrolling;

    private Animator anim;
    private int hashWalk = Animator.StringToHash("Walk");
    private int hashFinish = Animator.StringToHash("isFinish");
    private int hashAttack = Animator.StringToHash("Attack");
    private int hashRun = Animator.StringToHash("Run");
    private int hashDie = Animator.StringToHash("Die");

    void OnEnable()
    {
        StartCoroutine(CheckMonster());

        Debug.Log("OnEnable");
    }

    IEnumerator CheckMonster()
    {
        while (true)
        {
            yield return wfs;

            //몬스터와 플레이어사이의 거리를 구하기 위해 Vector3 클래스의 Distance 함수를 이용
            //this.transform.position = 몬스터의 좌표
            //heroTr.position = 플레이어의 좌표
            float distance = Vector3.Distance(this.transform.position, targetTr.position);

            if (distance <= 2.0)
            {
                //몬스터와 플레이어 거리가 매우 가까운 상황
                nv.speed = 0.1f;
                nv.autoBraking = false;
            }

            else if (distance > 2.0 && distance <= 16.0f)
            {
                //추적 모드
                nv.autoBraking = false;
                nv.speed = 3.0f;
                isPatrolling = false;

                ApproachTarget(targetTr.position);
            }

            else
            {
                //순찰 모드
                nv.speed = 2.0f;
                isPatrolling = true;
                var statue = GameObject.FindGameObjectWithTag("STATUE");
                targetTr = statue.GetComponent<Transform>();
                nv.SetDestination(targetTr.position);
            }

            if (boss_Energy <= 0)
            {
                nv.speed = 0;
                nv.autoBraking = false;
                nv.isStopped = true;
                anim.SetTrigger(hashDie);
            }
        }
    }

    IEnumerator Start()
    {
        nv = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        yield return new WaitForSeconds(3.0f);

        nv.speed = 2.0f;
        var statue = GameObject.FindGameObjectWithTag("STATUE");
        nv.SetDestination(targetTr.position);
        anim.SetTrigger(hashWalk);

    }

    void OnCollisionEnter(Collision coll1)
    {
        if (coll1.collider.CompareTag("MISSILE"))
        {
            boss_Energy -= 1;
            anim.SetTrigger(hashRun);
            nv.isStopped = false;
            var player = GameObject.FindGameObjectWithTag("Player");
            targetTr = player.GetComponent<Transform>();
            nv.SetDestination(targetTr.position);
        }

        else if (coll1.collider.CompareTag("STATUE"))
        {
            nv.speed = 0.1f;
            nv.autoBraking = false;
            nv.isStopped = true;
            anim.SetTrigger(hashAttack);
        }

        else if (coll1.collider.CompareTag("Player"))
        {
            anim.SetTrigger(hashAttack);
        }

        else return;
    }

    void ApproachTarget(Vector3 pos)
    {
        if (nv.isPathStale) return;
        nv.destination = pos;
        nv.isStopped = false;
    }
}
