using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Minion, IEnemy, IMeleeFighter
{
    public void SetEnemyTag()
    {
        tag = IEnemy.EnemyTag;
    }

    public MeleeWeapon MeleeWeapon { get; set; }
    public void InitializeMeleeWeapon()
    {
        MeleeWeapon = gameObject.AddComponent<MeleeWeapon>();
        //MeleeWeapon.Initialize();
    }

    public void Attack()
    {
        MeleeWeapon.Attack();
    }
}
