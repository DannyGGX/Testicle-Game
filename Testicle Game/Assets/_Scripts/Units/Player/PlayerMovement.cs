using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private float moveSpeed = 8;
    private Vector2 inputNormalized;
    private Vector2 moveVector;
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void GetInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        inputNormalized = new Vector2(moveX, moveY).normalized;
    }
    

    private void Move()
    {
        moveVector = moveSpeed * inputNormalized;
        rigidBody.velocity = moveVector;
    }
    
}
