using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergyDropperAttributes
{
    [field: SerializeField] public int EnergyToDrop { get; set; }
}
