﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 5f;

    private bool walk;
    private bool attack;
    private float distance;

    public Animator animator;

    Transform target;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManage.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && distance > attackRadius)
        {
            attack = false;
            walk = true;
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                //Attack
                //Face target
                FaceTarget();
            }
        }
        if(distance <= attackRadius)
        {
            walk = false;
            attack = true;
        }
        if(distance > lookRadius)
        {
            attack = false;
            walk = false;
        }
        Animations();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
    public void Animations()
    {
        animator.SetBool("walk", walk);
        animator.SetBool("attack", attack);
        animator.SetFloat("distance", distance);
    }
}
