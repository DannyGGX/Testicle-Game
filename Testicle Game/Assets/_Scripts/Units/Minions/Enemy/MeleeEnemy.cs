using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Minion, IEnemy
{
    [Header("NavMesh Properties")]
    [SerializeField] private float stoppingDistance = 2;
    
    
    private void Awake()
    {
        BaseAwake();
        SetMeleeMinionStats();
        SetEnemyTagAndLayer();
    }

    private void OnEnable()
    {
        BaseOnEnable();
    }

    private void OnDisable()
    {
        BaseOnDisable();
    }

    public void SetEnemyTagAndLayer()
    {
        tag = IEnemy.EnemyTag;
        gameObject.layer = IEnemy.EnemyLayer;
    }

    private void SetMeleeMinionStats()
    {
        agent.stoppingDistance = stoppingDistance;
        
    }
}
