using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Minion : Unit, ITargetter
{
    [SerializeField] protected Vision minionVision;
    [SerializeField] protected WeaponRange attackRange;
    [SerializeField] protected AIWeaponRotation weaponRotation;
    
    protected NavMeshAgent agent;
    private CustomObjectPool<Minion> minionPool;

    public void Initialize(CustomObjectPool<Minion> minionPool, Transform opponentBase)
    {
        minionVision.Initialize(opponentBase);
        this.minionPool = minionPool;
    }
    
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        if (CheckForIDMatch(unitID) == false)
            return;
        
        minionPool?.ReturnObject(this);
    }

    protected override void BaseAwake()
    {
        base.BaseAwake();
        agent = GetComponent<NavMeshAgent>();
        ConfigureNavMeshAgent();
        
        DisableWeapon();
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

    public void DisableWeapon()
    {
        weaponRotation.enabled = false;
    }

    public void EnableWeapon()
    {
        
    }

    protected override void BaseOnEnable()
    {
        base.BaseOnEnable();
        
    }

    protected override void BaseOnDisable()
    {
        base.BaseOnDisable();
        
    }

    private void InitializeWeapon()
    {
        
    }
    public void Attack()
    {
        
    }
}
