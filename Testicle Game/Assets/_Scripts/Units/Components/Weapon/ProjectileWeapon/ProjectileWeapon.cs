using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Gun
{
    private float BulletsPerSecond = 2;

    private Projectile BulletPrefab;
    private CustomObjectPool<Projectile> BulletPool;
    private Transform firePoint;
    
}
