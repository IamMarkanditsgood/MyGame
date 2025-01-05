using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSkill : BasicBuffSkill
{
    public override void BuffPlayer()
    {
        float buffPercent = _skillConfig.GetParameter(SkillParameterType.BuffPercent);
        CharacterEvents.ModifyPlayerParameter(PlayerParameterTypes.Health, buffPercent);
    }
}
