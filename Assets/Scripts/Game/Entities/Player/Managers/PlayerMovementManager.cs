﻿using System;
using UnityEngine;

public class PlayerMovementManager
{
    private CharacterController _characterController;
    private float _movementSpeed;
    private Vector3 _velocity;
    private Transform _playerBody;

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
}