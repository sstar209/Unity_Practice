using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Move2 : MonoBehaviour
{
    private NavMeshAgent nv;
    public Transform targetTr;

    private Animator anim;
    private int hashWalk = Animator.StringToHash("Walk");
    private int hashFinish = Animator.StringToHash("isFinish");

    IEnumerator Start()
    {
        nv = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        yield return new WaitForSeconds(3.0f);

        var statue = GameObject.FindGameObjectWithTag("STATUE");
        nv.SetDestination(targetTr.position);
        anim.SetTrigger(hashWalk);
    }

    void OnCollisionEnter(Collision coll2)
    {
        if(coll2.collider.CompareTag("STATUE"))
        {
            nv.isStopped = true;
            anim.SetTrigger(hashFinish);
        }
    }



}
