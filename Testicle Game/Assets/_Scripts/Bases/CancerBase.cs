using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerBase : Base, IEnemy, IEnergyDropper
{
    public void SetEnemyTag()
    {
        tag = IEnemy.EnemyTag;
    }
}
