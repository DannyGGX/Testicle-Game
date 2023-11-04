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
    [SerializeField] protected CustomObjectPool<Minion> minionPool;

    public void GetMinionPoolReference(CustomObjectPool<Minion> minionPool)
    {
        this.minionPool = minionPool;
    }
    
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        if (CheckForIDMatch(unitID) == false)
            return;
        
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
