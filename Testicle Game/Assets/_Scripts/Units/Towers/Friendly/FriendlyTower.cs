using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FriendlyTower : Tower, IFriendly, IDamagable, ITargetter, ITargetable
{
    public Health HealthComponent { get; set; }

    public void Die()
    {
        // become NoTower
    }
    

}
