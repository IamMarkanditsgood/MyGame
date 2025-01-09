using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BasicSkill
{
    [SerializeField] protected BasicSkillConfig _skillConfig;

    public BasicSkillConfig SkillConfig { get { return _skillConfig; } set { _skillConfig = value; } }

    public abstract void UseSkill();
}