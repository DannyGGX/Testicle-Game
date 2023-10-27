using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour, ITargetable, IDamagable
{
    [field: SerializeField] public Health HealthComponent { get; set; }

    public void Die()
    {
        
    }

}
