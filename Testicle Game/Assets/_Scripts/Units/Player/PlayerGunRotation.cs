using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotation : MonoBehaviour
{
    private Camera mainCam;
    private Quaternion rotation;
    private const float ROTATION_OFFSET = -90;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {

        rotation = GetRotationInput();
    }

    private void FixedUpdate()
    {
        RotateToMouse();
    }
    private Quaternion GetRotationInput()
    {
        Vector2 direction = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ROTATION_OFFSET;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void RotateToMouse()
    {
        transform.rotation = rotation;
    }
}
