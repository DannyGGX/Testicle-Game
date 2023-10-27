using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private int weaponDamage;
    private Animation weaponAnimation;
    private Collider weaponCollider;
    private bool isFriendly;
    private string opponentTag;
    private float attackDuration;

    public void Initialize(int weaponDamage, Animation weaponAnimation, Collider weaponCollider, bool isFriendly)
    {
        this.weaponDamage = weaponDamage;
        this.weaponAnimation = weaponAnimation;
        this.weaponCollider = weaponCollider;
        this.isFriendly = isFriendly;

        opponentTag = isFriendly ? "Friendly" : "Enemy";

        weaponCollider.isTrigger = true;
        DisableCollider();
    }
    
    public void Attack()
    {
        EnableCollider();
        attackDuration = weaponAnimation.clip.length;


    }

    private void EnableCollider()
    {
        weaponCollider.enabled = true;
    }

    private void DisableCollider()
    {
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(opponentTag))
        {
            other.GetComponent<IDamagable>().HealthComponent.TakeDamage(weaponDamage);
        }
    }
}
