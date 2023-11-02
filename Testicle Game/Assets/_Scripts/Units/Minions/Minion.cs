using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : Unit, ITargetter
{
    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        
    }


}
