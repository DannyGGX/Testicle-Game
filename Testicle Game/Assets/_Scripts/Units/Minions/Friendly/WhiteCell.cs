using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : Minion, IFriendly, IMeleeFighter
{
    public MeleeWeapon MeleeWeapon { get; set; }
    public void InitializeMeleeWeapon()
    {
        MeleeWeapon = gameObject.AddComponent<MeleeWeapon>();
        //MeleeWeapon.Initialize();
    }

    public void Attack()
    {
        this.MeleeWeapon.Attack();
    }
}
