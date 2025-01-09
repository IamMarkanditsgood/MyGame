using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character/Character/Player", order = 1)]
public class CharacterConfig : SerializedScriptableObject
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private List<SkillTypes> _skills;
    [SerializeField] private Dictionary<PlayerParameterTypes, float> _parameters;
    [SerializeField] private Dictionary<SkillTypes, BasicSkillConfig> _skillsCollection;

    public GameObject CharacterPrefab => _characterPrefab;
    public List<SkillTypes> Skills => _skills;
    public Dictionary<PlayerParameterTypes, float> Parameters => _parameters;
    public Dictionary<SkillTypes, BasicSkillConfig> SkillsCollection => _skillsCollection;
}