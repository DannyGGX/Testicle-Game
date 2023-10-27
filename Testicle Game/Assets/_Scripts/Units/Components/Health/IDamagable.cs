
using Unity.VisualScripting;
using UnityEngine;

public interface IDamagable
{
    public Health HealthComponent { get; set; }
    void Die();

}
