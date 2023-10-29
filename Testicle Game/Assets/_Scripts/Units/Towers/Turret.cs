using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float turretRotationSpeed;

    private RaycastHit2D hitInfo;
    private float range = 10;
    private LayerMask unitsLayer;

    private ITargetable currentTarget;
    
    private Gun turretGun;
    
    
    public void RotateTowardsTarget(ITargetable target) // called by TurretTargetting
    {
        
    }

    private bool CheckIfTurretPointingToTarget(ITargetable target)
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, range, unitsLayer))
        {
            return true;
        }

        return false;
    }

    private void FixedUpdate()
    {
        if (CheckIfTurretPointingToTarget(currentTarget))
        {
            
        }
    }

    private void ShootOnce()
    {
        turretGun.Shoot();
    }
}
