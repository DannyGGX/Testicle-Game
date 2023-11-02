using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class FriendlyTower : Tower, IFriendly, ITargetter
{
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        // become NoTower maybe send event for that
    }

}
