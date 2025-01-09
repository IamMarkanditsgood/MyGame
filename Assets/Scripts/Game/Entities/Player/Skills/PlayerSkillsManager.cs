using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSkillsManager
{
    private List<SkillTypes> _skills;
    private List<BasicSkill> _playerSkills = new List<BasicSkill>();

    private Dictionary<SkillTypes, BasicSkillConfig> _skillsCollection;
    private Dictionary<SkillTypes, BasicSkill> _availableSkills = new Dictionary<SkillTypes, BasicSkill>
    {
        { SkillTypes.Healer,new HealerSkill() },
        { SkillTypes.Booster,new BoosterSkill() }
    };

    public void Init(Dictionary<SkillTypes, BasicSkillConfig> skillsCollection, List<SkillTypes> skills)
    {
        _skillsCollection = skillsCollection;
        _skills = skills;
        SetSkills();
    }

    private void SetSkills()
    {
        _playerSkills.Clear(); 

        foreach (var skillType in _skills)
        {
            if (_availableSkills.TryGetValue(skillType, out var skill))
            {
                _playerSkills.Add(skill);
                _playerSkills[_playerSkills.Count - 1].SkillConfig = GetSkillConfig(skillType);
            }
        }
    }

    private BasicSkillConfig GetSkillConfig(SkillTypes skillType)
    {
        if (_skillsCollection == null)
        {
            Debug.LogError("Skills collection is not initialized!");
            return null;
        }

        if (_skillsCollection.TryGetValue(skillType, out var skillConfig))
        {
            return skillConfig; 
        }

        Debug.LogWarning($"Skill config for {skillType} not found.");
        return null; 
    }
}