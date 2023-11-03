using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Minion, IEnemy, IMeleeFighter
{
    [Header("NavMesh Properties")]
    [SerializeField] private float stoppingDistance = 2;
    [field: Space]
    [field: SerializeField] public MeleeWeapon MeleeWeapon { get; set; }
    
    
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
    
    
    public void InitializeMeleeWeapon()
    {
        //MeleeWeapon.Initialize();
    }

    public void Attack()
    {
        MeleeWeapon.Attack();
    }
}
