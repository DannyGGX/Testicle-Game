using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamagable
{
    public int UnitID { get; set; }

    private void SetUnitID()
    {
        UnitID = GetInstanceID();
    }
    private void OnEnable()
    {
        EventManager.OnUnitDie.Subscribe(Die);
    }

    private void OnDisable()
    {
        EventManager.OnUnitDie.Unsubscribe(Die);
    }
    private void Awake()
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
