using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesSO", menuName = "Scriptable Object/Unit Attribute/Player")]
public class PlayerAttributesSO : UnitAttributesSO, IProjectileAttributes
{
   
   [field: Header("Gun")]
   [field: SerializeField]  public float BulletsPerSecond { get; set; }
   [field: SerializeField]  public Projectile BulletPrefab { get; set; }
   public CustomObjectPool<Projectile> BulletPool { get; set; }
}
