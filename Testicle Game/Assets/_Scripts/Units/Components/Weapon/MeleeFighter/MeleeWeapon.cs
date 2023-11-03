using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class MeleeWeapon : Weapon
{
    [SerializeField] private int weaponDamage;

    [SerializeField] private TargetTypes opponent;
    [SerializeField] private float attackDuration;

    private CircleCollider2D weaponCollider;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    
    
    private WaitForSeconds attackWait;

    [HideInInspector] public bool isAttackCoroutineRunning;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        weaponCollider = GetComponent<CircleCollider2D>();
        //attackDuration = weaponAnimation.clip.length;
        attackWait = new WaitForSeconds(attackDuration);
        spriteRenderer = GetComponent<SpriteRenderer>();
        DisableColliderAndSpriteRenderer();
    }

    
    public override void Attack()
    {
        if(isAttackCoroutineRunning) return;

        StartCoroutine(AttackOnce());

    }

    private void EnableColliderAndSpriteRenderer()
    {
        weaponCollider.enabled = true;
        spriteRenderer.enabled = true;
    }

    private void DisableColliderAndSpriteRenderer()
    {
        weaponCollider.enabled = false;
        spriteRenderer.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(opponent.ToString()))
        {
            this.Log("Damage target");
            other.GetComponent<IDamagable>().HealthComponent.TakeDamage(weaponDamage);
            DisableColliderAndSpriteRenderer();
        }
    }

    private IEnumerator AttackOnce()
    {
        this.Log("Coroutine playing");
        isAttackCoroutineRunning = true;
        EnableColliderAndSpriteRenderer();
        _animator.Play("Slash", -1);
        
        yield return attackWait;
        isAttackCoroutineRunning = false;
    }
}
