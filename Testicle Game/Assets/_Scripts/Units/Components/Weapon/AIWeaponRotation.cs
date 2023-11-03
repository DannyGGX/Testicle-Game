using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponRotation : MonoBehaviour
{
    private Transform currentTarget;
    private Quaternion rotation;
    private const float ROTATION_OFFSET = -90;
    
    public Quaternion GetRotationToTarget(Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ROTATION_OFFSET;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void GetTarget(Transform target)
    {
        currentTarget = target;
    }

    private void FixedUpdate()
    {
        transform.rotation = GetRotationToTarget(currentTarget.position);
    }
}
