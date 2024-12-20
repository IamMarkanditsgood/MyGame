using UnityEngine;

public class PlayerRotationManager
{
    private Transform _playerBody;
    private float _rotationSpeed;

    public void Init(Transform playerBody, float rotarionSpeed)
    {
        _playerBody = playerBody;
        _rotationSpeed = rotarionSpeed;
    }

    public void Rotate(Vector2 mouseMovement)
    {
        float mouseX = mouseMovement.x * _rotationSpeed * Time.deltaTime;
        float mouseY = mouseMovement.y * _rotationSpeed * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
