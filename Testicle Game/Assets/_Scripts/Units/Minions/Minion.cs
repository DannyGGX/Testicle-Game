using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Minion : Unit, ITargetter
{
    protected NavMeshAgent agent;
    [SerializeField] protected Vision minionVision;
    [SerializeField] protected WeaponRange attackRange;
    [SerializeField] protected AIWeaponRotation weaponRotation;
    
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        
    }

    protected override void BaseAwake()
    {
        base.BaseAwake();
        agent = GetComponent<NavMeshAgent>();
        ConfigureNavMeshAgent();
    }
    private void ConfigureNavMeshAgent()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetAgentDestination(Vector2 target)
    {
        agent.SetDestination(target);
    }

    

    protected override void BaseOnEnable()
    {
        base.BaseOnEnable();
        
    }

    protected override void BaseOnDisable()
    {
        base.BaseOnDisable();
        
    }
}
