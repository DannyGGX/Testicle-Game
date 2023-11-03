using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerBase : Base, IEnemy, IEnergyDropper
{
    public void SetEnemyTagAndLayer()
    {
        tag = IEnemy.EnemyTag;
    }
}
