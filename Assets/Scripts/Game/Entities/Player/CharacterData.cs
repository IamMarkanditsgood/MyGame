using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    public GameObject CharacterPrefab { get { return _characterPrefab; } set { _characterPrefab = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float RotationSpeed { get { return _rotationSpeed; } set { _rotationSpeed = value; } }
}
