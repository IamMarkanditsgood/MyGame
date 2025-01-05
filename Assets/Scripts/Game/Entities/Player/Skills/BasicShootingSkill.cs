using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicShootingSkill : BasicSkill
{
    [SerializeField] protected Transform _spawnPos;
    [SerializeField] protected GameObject _prefab;

    public override void UseSkill()
    {
        Shoot();
    }
    public abstract void Shoot();
}
