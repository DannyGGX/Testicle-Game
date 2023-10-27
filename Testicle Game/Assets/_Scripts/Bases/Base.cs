using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Unit, ITargetable, IDamagable
{
    [field: SerializeField] public Health HealthComponent { get; set; }
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        
    }
}
