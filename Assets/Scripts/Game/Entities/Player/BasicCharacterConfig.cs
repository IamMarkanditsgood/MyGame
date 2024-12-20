using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterConfig", order = 1)]
public class BasicCharacterConfig : ScriptableObject
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    public GameObject CharacterPrefab => _characterPrefab;
    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
}