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

    private float projectileSpeed = 10;
    private float maxActiveDuration = 2;
    private Rigidbody2D rigidBody;
    private void OnEnable()
    {
        Invoke(nameof(DisableProjectile), maxActiveDuration);
        rigidBody = GetComponent<Rigidbody2D>();
        ApplyBulletMovement();
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(DisableProjectile));
    }

    public virtual void Initialize(CustomObjectPool<Projectile> bulletPool, int speed, params TargetTypes[] targetTypes)
    {
        this.bulletPool = bulletPool;
        projectileSpeed = speed;
        this.targetTypes = targetTypes;
    }

    private void ApplyBulletMovement()
    {
        rigidBody.velocity = projectileSpeed * transform.up;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (IsObjectATarget(other))
        {
            // Damage target
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
