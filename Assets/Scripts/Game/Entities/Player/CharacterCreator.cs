using System;
using UnityEngine;

[Serializable]
public class CharacterCreator
{
    [SerializeField] private Transform _characterSpawnPos;

    private BasicCharacterConfig _characterConfig;
    private PlayerController _character;

    public void Init(BasicCharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;
    }

    public PlayerController CreateCharacter()
    {
        GameObject character = UnityEngine.Object.Instantiate(_characterConfig.CharacterPrefab);
        character.transform.position = _characterSpawnPos.position;
        _character = character.GetComponent<PlayerController>();
        _character.Init(_characterConfig);

        return _character;
    }
}
