using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsManager
{
    private List<SkillTypes> _skills;
    private List<BasicSkill> _playerSkills = new List<BasicSkill>();

    private Transform _shootingPos;
    private Transform _playerPos;


    private Dictionary<SkillTypes, BasicSkillConfig> _skillsCollection;
    private Dictionary<SkillTypes, BasicSkill> _availableSkills = new Dictionary<SkillTypes, BasicSkill>
    {
        { SkillTypes.BallShot,new BulletShot() },
        { SkillTypes.Healer,new HealerSkill() },
        { SkillTypes.Booster,new BoosterSkill() }
    };

    public void Init(Dictionary<SkillTypes, BasicSkillConfig> skillsCollection, List<SkillTypes> skills, Transform playerPos, Transform shootingPos)
    {
        _skillsCollection = skillsCollection;
        _skills = skills;
        _playerPos = playerPos;
        _shootingPos = shootingPos;
        SetSkills();
    }

    public void Disable()
    {
        foreach (var skill in _playerSkills)
        {
            skill.StopCoroutines();
        }
    }

    private void SetSkills()
    {
        _playerSkills.Clear();

        foreach (var skillType in _skills)
        {
            if (_availableSkills.TryGetValue(skillType, out var skill))
            {
                InitSkill(skill);
                _playerSkills.Add(skill);
                _playerSkills[_playerSkills.Count - 1].SkillConfig = GetSkillConfig(skillType);              
            }
        }
    }

    private void InitSkill(BasicSkill _playerSkill)
    {
        if (_playerSkill is BasicShootingSkill)
        {
            BasicShootingSkill basicShootingSkill = (BasicShootingSkill)_playerSkill;
            basicShootingSkill.Init(_shootingPos);
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

    public void UseSkill(int skillIndex)
    {
        int lastSkillIndex = _playerSkills.Count - 1;
        if (skillIndex > lastSkillIndex)
        {
            skillIndex = lastSkillIndex;
            Debug.LogWarning($"skill Index {skillIndex} out of range!");
        }

        _playerSkills[skillIndex].UseSkill();
    }
}