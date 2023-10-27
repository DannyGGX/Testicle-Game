using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeleeFighter
{
    public MeleeWeapon MeleeWeapon { get; set; }
    void InitializeMeleeWeapon();
    void Attack();
}
