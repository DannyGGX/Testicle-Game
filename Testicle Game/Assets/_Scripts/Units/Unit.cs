using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamagable, ITargetable
{
    protected int UnitID { get; set; }
    [field: SerializeField] public Health HealthComponent { get; set; }

    private void SetUnitID()
    {
        UnitID = gameObject.GetInstanceID();
    }

    protected virtual void BaseOnEnable()
    {
        EventManager.OnUnitDie.Subscribe(Die);
        
        HealthComponent?.InitializeHealthBar(UnitID);
    }

    protected virtual void BaseOnDisable()
    {
        EventManager.OnUnitDie.Unsubscribe(Die);
    }

    protected virtual void BaseAwake()
    {
        SetUnitID();
    }
    protected bool CheckForIDMatch(int unitID)
    {
        return UnitID == unitID;
    }
    
    public virtual void Die(int unitID)
    {
        if (CheckForIDMatch(unitID) == false)
            return;
        
        
    }
}
