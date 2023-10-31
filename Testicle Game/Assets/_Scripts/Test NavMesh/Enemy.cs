using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ConfigureNavMeshAgent();
    }

    private void ConfigureNavMeshAgent()
    {
        //agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
        
    }
}
