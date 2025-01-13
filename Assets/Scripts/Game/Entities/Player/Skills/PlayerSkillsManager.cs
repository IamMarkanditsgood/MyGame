using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsManager
{
    private List<SkillTypes> _skills;
    private List<BasicSkill> _playerSkills = new List<BasicSkill>();

    private Transform _shootingPos;
    private Transform _characterPos;


    private Dictionary<SkillTypes, BasicSkillConfig> _skillsCollection;
    private Dictionary<SkillTypes, BasicSkill> _availableSkills = new Dictionary<SkillTypes, BasicSkill>
    {
        { SkillTypes.Lazer,new Lazer() },
        { SkillTypes.ShotGun,new ShotGun() },
        { SkillTypes.BallShot,new BulletShot() },
        { SkillTypes.Healer,new HealerSkill() },
        { SkillTypes.Booster,new BoosterSkill() },
        { SkillTypes.Teleporter,new PlayerTeleport() },
        { SkillTypes.Shield,new Shield() },
        { SkillTypes.Wave,new Wave() },
        { SkillTypes.Sword,new Swords() },
        { SkillTypes.Drone,new Drone() },
        { SkillTypes.Mine,new MineSkill() }
    };

    public void Init(Dictionary<SkillTypes, BasicSkillConfig> skillsCollection, List<SkillTypes> skills, Transform characterPos, Transform shootingPos)
    {
        _skillsCollection = skillsCollection;
        _skills = skills;
        _characterPos = characterPos;
        _shootingPos = shootingPos;
        SetSkills();
    }

    public void Disable()
    {
        foreach (var skill in _playerSkills)
        {
            skill.StopCoroutines();
        }
        foreach (var skill in _playerSkills)
        {
            skill.OnDisable();
        }
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
                InitSkill(skill);
            }
        }
    }

    private void InitSkill(BasicSkill _playerSkill)
    {
        _playerSkill.Init(_characterPos);

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