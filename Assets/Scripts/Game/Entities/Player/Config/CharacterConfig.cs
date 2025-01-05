using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character/Character/Player", order = 1)]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _health;
    [SerializeField] private float _damageResistance;

    public GameObject CharacterPrefab => _characterPrefab;
    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float Health => _health;
    public float DamageResistance => _damageResistance;
}