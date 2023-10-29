using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UnitAttributesSO : ScriptableObject
{
    [Header("Health")] 
    public int MaxHealth;
    public HealthBar HealthUI;
    
}
