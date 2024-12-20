using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/SkillConfig", order = 1)]
public class SkillConfig : ScriptableObject
{
    [SerializeField] private SkillTypes _skillType;
    [SerializeField] private float _rechargeTime;

    public SkillTypes SkillType => _skillType;
    public float RechargeTime => _rechargeTime;
}
