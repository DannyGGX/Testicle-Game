using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    
    private const string animatorParameterName = "State";
    private static readonly int animatorParameter = Animator.StringToHash(animatorParameterName);
    
    private bool isDead = false;

    private void OnEnable()
    {
        EventManager.OnPlayerDie.Subscribe(PlayDeath);
        EventManager.OnPlayerRevive.Subscribe(Revive);
        
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDie.Unsubscribe(PlayDeath);
        EventManager.OnPlayerRevive.Unsubscribe(Revive);
    }

    private void LateUpdate()
    {
        if (isDead) return;

        if (rigidBody.velocity.magnitude > 0)
        {
            PlayRun();
        }
        else
        {
            PlayIdle();
        }
    }

    private void PlayIdle()
    {
        SetAnimator((int)States.Idle);
    }

    private void PlayRun()
    {
        SetAnimator((int)States.Run);
    }

    private void PlayDeath()
    {
        SetAnimator((int)States.Death);
        isDead = true;
    }

    private void Revive()
    {
        isDead = false;
    }
    
    private void SetAnimator(int stateID)
    {
        animator.SetInteger(animatorParameter, stateID);
    }

    private enum States
    {
        Idle,
        Run,
        Death
    }
    
}
