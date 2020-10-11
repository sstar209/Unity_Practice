using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss_Move2 : MonoBehaviour
{
    private NavMeshAgent nv;
    public Transform targetTr;
    public int boss_Energy = 77;
    private WaitForSeconds wfs;
    public Vector3 targetPosition;

    private Animator anim;
    private int hashWalk = Animator.StringToHash("Walk");
    private int hashFinish = Animator.StringToHash("isFinish");
    private int hashIsAttack = Animator.StringToHash("isAttack");
    private int hashAttack = Animator.StringToHash("Attack");
    private int hashRun = Animator.StringToHash("Run");
    private int hashDie = Animator.StringToHash("Die");

    public bool attacked = false;

    void OnEnable()
    {
        StartCoroutine(CheckMonster());
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

            if (distance <= 4.0)
            {
                //거리가 매우 가까운 상황
                nv.speed = 0.01f;
                nv.autoBraking = false;

                anim.SetBool(hashIsAttack, true);
                anim.SetTrigger(hashAttack);
            }

            else if (distance > 4.0 && distance <= 16.0f)
            {
                //추적 모드
                nv.autoBraking = false;
                nv.speed = 4.5f;

                anim.SetBool(hashIsAttack, false);
                anim.SetBool(hashFinish, true);
                anim.SetTrigger(hashRun);

                ApproachTarget(targetTr.position);        
            }

            else
            {
                //순찰 모드
                nv.speed = 3.0f;
                var statue = GameObject.FindGameObjectWithTag("STATUE");
                targetTr = statue.GetComponent<Transform>();

                anim.SetTrigger(hashWalk);

                nv.SetDestination(targetTr.position);
            }
        }
    }

    void Start()
    {
        nv = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        wfs = new WaitForSeconds(0.1f);

        nv.speed = 3.0f;
        nv.autoBraking = false;

        var statue = GameObject.FindGameObjectWithTag("STATUE");  //추적할 목표를 찾자
        targetTr = statue.GetComponent<Transform>();              //추적할 목표를 지정

        anim.SetTrigger(hashWalk);                                //걷는 애니메이션     
        anim.SetBool(hashFinish, false);
        anim.SetBool(hashIsAttack, false);
    }

    void OnCollisionEnter(Collision coll9)
    {
        //미사일과 접촉 시
        if (coll9.collider.CompareTag("MISSILE"))
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            targetTr = player.GetComponent<Transform>();
            boss_Energy -= 1;
            nv.isStopped = false;
            anim.SetBool(hashFinish, true);
            anim.SetTrigger(hashRun);
        }
    }
    
    void OnCollisionStay(Collision coll1)
    {
        //석상 접촉 시
        if (coll1.collider.CompareTag("STATUE"))
        {
            nv.speed = 0;
            nv.autoBraking = false;
            nv.isStopped = true;
            anim.SetBool(hashIsAttack, true);
            anim.SetTrigger(hashAttack);

            if (attacked)
            {
                Debug.Log("MinusHp");
                anim.SetBool(hashFinish, false);
                StatueEnergy.instance8.StatueBossDamage();
                attacked = false;
            }
        }

        //플레이어 접촉 시
        if(coll1.collider.CompareTag("Player"))
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            targetTr = player.GetComponent<Transform>();

            nv.speed = 0;
            nv.autoBraking = false;
            nv.isStopped = true;
            anim.SetBool(hashIsAttack, true);
            anim.SetTrigger(hashAttack);

            if (attacked)
            {
                Debug.Log("MinusHp");
                anim.SetBool(hashFinish, false);
                HeroEnergy.instance7.PlayerBossDamage();
                attacked = false;
            }
        }
    }

    void ApproachTarget(Vector3 pos)
    {
        if (nv.isPathStale) return;
        nv.destination = pos;
        nv.isStopped = false;
    }

    void AttackTrue()
    {
        attacked = true;
        SoundManager.instance5.DamageSound();
    }

    void AttackFalse()
    {
        attacked = false;
    }

    void Update()
    {
        if (boss_Energy <= 0)
        {
            nv.speed = 0;
            nv.autoBraking = false;
            nv.isStopped = true;
            anim.SetTrigger(hashDie);
        }

        if (GameManager.instance.endGame == true)
        {
            Destroy(this.gameObject);
        }
    }
}