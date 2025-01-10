using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicShootingSkill : BasicSkill
{
    [SerializeField] protected Transform _spawnPos;

    public void Init(Transform shootingPos)
    {
        _spawnPos = shootingPos;
    }
    public override void ActivateSkill()
    {
        Shoot();
    }
    public abstract void Shoot();
}
