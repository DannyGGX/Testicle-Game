using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour, IDamagable, ITargetter, ITargetable
{
    public Health HealthComponent { get; set; }

    public void Die()
    {
        
    }
}
