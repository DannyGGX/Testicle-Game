using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Minion, IEnemy, IProjectileShooter
{
    public void SetEnemyTagAndLayer()
    {
        tag = IEnemy.EnemyTag;
    }
}
