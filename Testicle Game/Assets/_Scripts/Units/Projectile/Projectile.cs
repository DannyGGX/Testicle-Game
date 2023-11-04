using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public Unit Shooter;
    private TargetTypes[] targetTypes;
    private CustomObjectPool<Projectile> bulletPool;
    [SerializeField] private int damage = 20;

    private float projectileSpeed = 10;
    private float maxActiveDuration = 2;
    private Rigidbody2D rigidBody;
    private Transform firePoint;
    
    private void OnEnable()
    {
        Invoke(nameof(DisableProjectile), maxActiveDuration);
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(DisableProjectile));
    }

    public virtual void Initialize(CustomObjectPool<Projectile> bulletPool, Transform firePoint, int speed, params TargetTypes[] targetTypes)
    {
        this.bulletPool = bulletPool;
        projectileSpeed = speed;
        this.targetTypes = targetTypes;
        transform.position = firePoint.position;
        this.firePoint = firePoint;
        
        ApplyBulletMovement();
    }

    private void ApplyBulletMovement()
    {
        rigidBody.velocity = projectileSpeed * firePoint.up;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (IsObjectATarget(other))
        {
            other.gameObject.GetComponent<IDamagable>().HealthComponent.TakeDamage(damage);
            // Any other effect
        }
        
        DisableProjectile();
    }

    private bool IsObjectATarget(Collision2D other)
    {
        foreach (var targetType in targetTypes)
        {
            return other.gameObject.CompareTag(targetType.ToString());
        }

        return false;
    }

    private void DisableProjectile()
    {
        bulletPool.ReturnObject(this);
    }
}
