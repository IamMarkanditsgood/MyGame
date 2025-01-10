using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSkill", menuName = "ScriptableObjects/Character/Skills/ShootingSkill")]
public class ShootingSkillConfig : BasicSkillConfig
{
    [SerializeField] private BulletConfig _bulletConfig;

    public BulletConfig BulletConfig => _bulletConfig;
}
