using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster_Move : MonoBehaviour
{
    public List<Transform> movePoints;
    public int nextPoint = 0;
    public NavMeshAgent Monster_Agent;
    public Animator animator;
    public Vector3 targetPosition;
    public bool isPatrolling;

    void Start()
    {
        Monster_Agent = GetComponent<NavMeshAgent>();
        Monster_Agent.autoBraking = false;

        animator = GetComponent<Animator>();

        var p_group = GameObject.Find("EnemyMovePos");

        p_group.GetComponentsInChildren<Transform>(movePoints);
        movePoints.RemoveAt(0);
        movePoints.RemoveAt(0);
        Monster_Agent.speed = 1.0f;
    }

    void MoveMonster()
    {
        Monster_Agent.destination = movePoints[nextPoint].position;
    }

    void Update()
    {
        //추적모드일 경우 함수를 벗어난다.
        if (!isPatrolling) return;

        //순찰모드일 경우에만 이하 구문이 실행된다.
        if(Monster_Agent.remainingDistance <= 0.5f)
        {
            nextPoint = ++nextPoint % movePoints.Count;
            MoveMonster();
        }
    }
}
