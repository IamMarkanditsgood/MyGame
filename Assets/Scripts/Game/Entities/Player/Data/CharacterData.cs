using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField] private Transform _shootingPos;

    private GameObject _characterPrefab;
    private List<SkillTypes> _skills;

    private Dictionary<PlayerParameterTypes, float> _parameters;

    public Transform ShootingPos => _shootingPos;
    public GameObject CharacterPrefab { get { return _characterPrefab; } set { _characterPrefab = value; } }
    public List<SkillTypes> Skills { get { return _skills; } set { _skills = value; } }
    public Dictionary<PlayerParameterTypes, float> Parameters { get { return _parameters; } set { _parameters = value; } }

    public float GetParameter(PlayerParameterTypes playerParameterTypes)
    {
        return _parameters[playerParameterTypes];
    }
    public void SetParameter(PlayerParameterTypes playerParameterTypes, float newValue)
    {
        _parameters[playerParameterTypes] = newValue;
    }
}
