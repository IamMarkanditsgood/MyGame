using System;
using UnityEngine;

public class PlayerMovementManager
{
    private CharacterController _characterController;
    private float _movementSpeed;
    private Vector3 _velocity;
    private Transform _playerBody;
    private Vector3 _previousPosition;

    private const float gravity = -9.81f;

    public void Init(CharacterController characterController, float movementSpeed, Transform playerBody)
    {
        _characterController = characterController;
        _movementSpeed = movementSpeed;
        _playerBody = playerBody;
    }

    public void MoveCharacter(Vector2 moveDirection)
    {
        Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y);

        Vector3 localMovement = _playerBody.transform.TransformDirection(movement);

        _characterController.Move(localMovement * _movementSpeed * Time.deltaTime);

        ApplyGravity();
    }
    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;  
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void UpdateMovementDirection()
    {
        Vector3 currentPosition = _characterController.transform.position;
        Vector3 movementDirection = (currentPosition - _previousPosition).normalized;

        if (movementDirection.magnitude > 0.01f)
        {
            PlayerEvents.ModifyDirection(movementDirection);
        }
        else
        {
            movementDirection = movementDirection.normalized;
            PlayerEvents.ModifyDirection(movementDirection);
        }
        _previousPosition = currentPosition;
    }
}