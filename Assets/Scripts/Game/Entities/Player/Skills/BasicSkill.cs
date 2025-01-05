using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicSkill : MonoBehaviour
{
    [SerializeField] protected BasicSkillConfig _skillConfig;

    public abstract void UseSkill();
}