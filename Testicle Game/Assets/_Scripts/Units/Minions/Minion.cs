using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : Unit, IDamagable, ITargetter, ITargetable
{
    public Health HealthComponent { get; set; }
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        
    }

    

}
