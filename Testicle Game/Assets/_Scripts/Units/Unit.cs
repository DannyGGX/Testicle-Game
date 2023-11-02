using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamagable, ITargetable
{
    public int UnitID { get; set; }

    private void SetUnitID()
    {
        UnitID = GetInstanceID();
    }
    public virtual void BaseOnEnable()
    {
        EventManager.OnUnitDie.Subscribe(Die);
        
        HealthComponent?.InitializeHealthBar(UnitID);
    }

    public virtual void BaseOnDisable()
    {
        EventManager.OnUnitDie.Unsubscribe(Die);
    }

    public virtual void BaseAwake()
    {
        SetUnitID();
    }
    public bool CheckForIDMatch(int unitID)
    {
        return UnitID == unitID;
    }

    [field: SerializeField] public Health HealthComponent { get; set; }
    
    public virtual void Die(int unitID)
    {
        if (CheckForIDMatch(unitID) == false)
            return;
        
        
    }
}
