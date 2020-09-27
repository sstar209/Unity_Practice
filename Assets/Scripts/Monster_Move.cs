using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move : MonoBehaviour
{
    public List<Transform> movePoints;
    public int nextPoint = 0;
    public Transform heroTr;
    private WaitForSeconds wfs;
    public NavMeshAgent Monster_Agent;
    public Vector3 targetPosition;
    public bool isPatrolling;
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

            //몬스터와 플레이어사이의 거리를 구하기 위해 Vector3 클래스의 Distance 함수를 이용
            //this.transform.position = 몬스터의 좌표
            //heroTr.position = 플레이어의 좌표
            float distance = Vector3.Distance(this.transform.position, heroTr.position);

            if(distance <= 2.0)
            {
                //몬스터와 플레이어 거리가 매우 가까운 상황
                Monster_Agent.speed = 0.1f;
                Monster_Agent.autoBraking = false;
            }

            else if(distance > 2.0 && distance <= 8.0f)
            {
                //추적 모드
                Monster_Agent.autoBraking = false;
                Monster_Agent.speed = 1.0f;
                isPatrolling = false;

                ApproachTarget(heroTr.position);
            }
            else
            {
                //순찰 모드
                Monster_Agent.speed = 0.6f;
                isPatrolling = true;
                Monster_Agent.destination = movePoints[nextPoint].position;
            }
        }
    }

    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        heroTr = player.GetComponent<Transform>();
        wfs = new WaitForSeconds(0.4f);
    }

    void Start()
    {
        Monster_Agent = GetComponent<NavMeshAgent>();
        Monster_Agent.autoBraking = false;

        var p_group = GameObject.Find("EnemyMovePos");

        p_group.GetComponentsInChildren<Transform>(movePoints);
        movePoints.RemoveAt(0);
        isPatrolling = true;
        MoveMonster();
        Monster_Agent.speed = 1.0f;
    }

    void MoveMonster()
    {
        if(isPatrolling)
        {
            Monster_Agent.destination = movePoints[nextPoint].position;
            Monster_Agent.isStopped = false;
        }
    }

    //플레이어의 위치를 매개변수로 받아 몬스터의 목표 위치를 플레이어 위치로 선정하는 함수
    void ApproachTarget(Vector3 pos)
    {
        if (Monster_Agent.isPathStale) return;
        Monster_Agent.destination = pos;
        Monster_Agent.isStopped = false;
    }

    void Update()
    {
        //추적모드일 경우 update함수를 벗어나도록 return한다.
        if (!isPatrolling) return;

        //순찰모드일 경우에만 이하 구문이 실행된다.
        if(Monster_Agent.remainingDistance <= 0.5f)
        {
            nextPoint = ++nextPoint % movePoints.Count;
            MoveMonster();
        }
    }

    //몬스터가 미사일을 맞았을 시 체력이 1씩 감소
    //몬스터가 체력을 다할 경우 몬스터는 false가 되며 3초 후 spawnMonster 함수 발동
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("MISSILE"))
        {
            monster_Energy -= 1;
        }
        else return;

        if(monster_Energy <= 0)
        {
            this.gameObject.SetActive(false);
            Invoke("SpawnMonster", 3f);
            //Invoke 시간 지연 함수
        }
    }

    void SpawnMonster()
    {
        monster_Energy = 5;
        this.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), 0.5f, Random.Range(0, 1));
        this.gameObject.SetActive(true);
    }
}
