using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    private PlayerInput _input;
    
    private void Awake()
    {
        _input = new PlayerInput();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    
    public Vector2 MoveDirection { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool jumpHeld { get; private set; }
    
    private void Update()
    {
        MoveDirection = _input.PlayerMovement.Walk.ReadValue<Vector2>();
        jumpPressed = _input.PlayerMovement.Jump.triggered;
        jumpHeld = _input.PlayerMovement.Jump.IsPressed();
    }
}
