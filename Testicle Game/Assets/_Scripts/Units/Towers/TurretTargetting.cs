using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetting : MonoBehaviour
{

    private CircleCollider2D visionRadius;
    private ITargetable currentTarget;
    private bool readyForNewTarget = true;

    private TargetTypes opponentType;

    private Turret turret;
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CanTargetObjectInRange(other) == false) return;
        
        ObjectBecomesTarget(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        CanTargetObjectInRange(other);
        if (CanTargetObjectInRange(other))
        {
            ObjectBecomesTarget(other);
        }
        else
        {
            
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (CheckForTargetOutOfRange(other))
        {
            BecomeReadyForNextTarget();
        }
    }

    private bool CheckForTargetOutOfRange(Collision2D other)
    {
        return other is ITargetable && (ITargetable)other == currentTarget;
    }

    private void ObjectBecomesTarget(Collision2D other)
    {
        currentTarget = (ITargetable)other;
    }

    private void BecomeReadyForNextTarget()
    {
        readyForNewTarget = true;
        currentTarget = null;
    }

    private bool CanTargetObjectInRange(Collision2D other)
    {
        if (readyForNewTarget == false) return false;

        if (currentTarget != null) return false;

        if (other.gameObject.CompareTag(opponentType.ToString()) == false) return false;

        return true;
    }

    private void RotateTurret()
    {
        turret.RotateTowardsTarget(currentTarget);
    }
    
    
}
