using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterSkill", menuName = "ScriptableObjects/Character/Skills/BaseSkill")]
public class BasicSkillConfig : ScriptableObject
{
    [SerializeField] private SkillTypes _type;
    [SerializeField] private SkillParameterData[] _parameters;

    public SkillTypes Type => _type;
    public SkillParameterData[] Parameters => _parameters;

    public float GetParameter(SkillParameterType skillParameterType)
    {
        foreach (var parameter in _parameters)
        {
            if(parameter.SkillParameterType == skillParameterType)
            {
                return parameter.Value;
            }    
        }
        Debug.LogWarning("There is no this type of parameter!");
        return 0;
    }
}
