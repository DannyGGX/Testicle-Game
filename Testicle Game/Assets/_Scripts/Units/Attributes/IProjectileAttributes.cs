using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileAttributes
{
    public float BulletsPerSecond { get; set; }
    
    public Projectile BulletPrefab { get; set; }
    
    public CustomObjectPool<Projectile> BulletPool { get; set; }

}
