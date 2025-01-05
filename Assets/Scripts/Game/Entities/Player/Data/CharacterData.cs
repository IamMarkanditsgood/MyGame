using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _health;
    [SerializeField] private float _damageResistance;

    public GameObject CharacterPrefab { get { return _characterPrefab; } set { _characterPrefab = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float RotationSpeed { get { return _rotationSpeed; } set { _rotationSpeed = value; } }
    public float Health { get { return _health; } set { _health = value; } }
    public float DamageResistance { get { return _damageResistance; } set { _damageResistance = value; } }
}
