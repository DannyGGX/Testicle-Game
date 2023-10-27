using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class FriendlyTower : Tower, IFriendly, IDamagable, ITargetter, ITargetable
{
    public Health HealthComponent { get; set; }

    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        // become NoTower maybe send event for that
    }

}
