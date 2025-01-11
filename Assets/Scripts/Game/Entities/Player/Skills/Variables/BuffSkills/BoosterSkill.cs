using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSkill : BasicBuffSkill
{
    public override void BuffPlayer()
    {
        float buffPercent = _skillConfig.GetParameter(SkillParameterType.BuffPercent);

        var parametersToBuff = new[]
        {
            PlayerParameterTypes.Health,
            PlayerParameterTypes.DamageResistance,
            PlayerParameterTypes.MovementSpeed
        };

        foreach (var parameter in parametersToBuff)
        {
            PlayerEvents.ModifyPlayerParameter(parameter, buffPercent);
        }
    }
}
