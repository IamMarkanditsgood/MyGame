using System;
using UnityEngine;

[Serializable]
public class SkillParameterData 
{
    [SerializeField] private SkillParameterType _skillParameterType;
    [SerializeField] private float _value;

    public SkillParameterType SkillParameterType => _skillParameterType;

    public float Value => _value;
}
