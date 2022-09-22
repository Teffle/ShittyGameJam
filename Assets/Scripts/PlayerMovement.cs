using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputScript))]
[RequireComponent(typeof(Collisions))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 0.3f;
    public float groundFriction = 0.2f;
    public float airFriction = 0.1f;

    private Vector2 _currentVelocity;
    private float _moveSpeed;
    
    [Header("Jump")] 
    public float jumpForce = 10f;

    [Header("Restrictions")] 
    public float maxVelocityY = 16f;
    public float maxVelocityX = 6f;
    
    [Header("Components")]
    private InputScript _input;
    private Rigidbody2D _rb;
    //private BoxCollider2D _bcol; //_bCol
    private Collisions _pCol;

    //GetComponent
    private void Start()
    {
        _pCol = GetComponent<Collisions>();
        _input = GetComponent<InputScript>();
        _rb = GetComponent<Rigidbody2D>();
        //_bcol = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        //Jump
        if (_input.jumpPressed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
        //move
        
        // Store Rigidbody2D.Velocity in _velocity
        _currentVelocity = _rb.velocity;
        _currentVelocity.y = Mathf.Clamp(_currentVelocity.y, -maxVelocityY, maxVelocityY);

        // Change the Velocity
        if (_input.MoveDirection.x != 0)
        {
            _moveSpeed += _input.MoveDirection.x * acceleration;
            _moveSpeed = Mathf.Clamp(_moveSpeed, -maxVelocityX, maxVelocityX);
        }
        else
        {
            _moveSpeed = Mathf.Lerp(_moveSpeed, 0f, _pCol.IsGrounded() ? groundFriction : airFriction);
        }

        _currentVelocity.x = _moveSpeed;

    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        
        // Return current Velocity into Rigidbody2D.velocity
        _rb.velocity = _currentVelocity;
    }
}
