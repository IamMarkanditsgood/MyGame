using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBuffSkill : BasicSkill
{
    public override void UseSkill()
    {
        BuffPlayer();
    }
    public abstract void BuffPlayer();
}
