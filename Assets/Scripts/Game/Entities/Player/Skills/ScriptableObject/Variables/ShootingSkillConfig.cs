using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSkill", menuName = "ScriptableObjects/Character/Skills/ShootingSkill")]
public class ShootingSkillConfig : BasicSkillConfig
{
    [SerializeField] private GameObject _bulletPrefab;

    public GameObject BulletPrefab => _bulletPrefab;
}
