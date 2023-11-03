using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class WeaponRange : MonoBehaviour
{
    [SerializeField] private TargetTypes opponent;

    [SerializeField] private AIWeaponRotation WeaponRotation;
    private Transform currentTarget;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentTarget != null) return;
        
        if (other.gameObject.CompareTag(opponent.ToString()))
        {
            currentTarget = other.GetComponent<Transform>();
            WeaponRotation.enabled = true;
            WeaponRotation.GetTarget(currentTarget);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentTarget == null) return;

        if (other.gameObject.transform == currentTarget)
        {
            currentTarget = null;
            WeaponRotation.enabled = false;
        }
    }
}
