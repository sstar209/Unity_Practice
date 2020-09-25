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
        if(Monster_Agent.remainingDistance <= 0.5f)
        {
            nextPoint = ++nextPoint % movePoints.Count;
            MoveMonster();
        }
    }
}
