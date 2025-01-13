using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSkill", menuName = "ScriptableObjects/Character/Skills/SpawnSkillConfig")]

public class SpawnerSkillConfig : BasicSkillConfig
{
    [SerializeField] private GameObject _objectPref;

    public GameObject ObjectPrefab => _objectPref;
}
