using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public static string EnemyTag => "Enemy";

    void SetEnemyTag();
}
