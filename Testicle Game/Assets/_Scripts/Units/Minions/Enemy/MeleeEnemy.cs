using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Minion, IEnemy, IMeleeFighter
{
    public void SetEnemyTag()
    {
        tag = IEnemy.EnemyTag;
    }
}
