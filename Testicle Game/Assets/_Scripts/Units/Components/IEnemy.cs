using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public static string EnemyTag => "Enemy";
    public static LayerMask EnemyLayer => LayerMask.NameToLayer("Enemy");

    void SetEnemyTagAndLayer();
}
