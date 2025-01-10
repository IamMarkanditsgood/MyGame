using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : BasicShootingSkill
{
    public override void Shoot()
    {
        ShootingSkillConfig skillConfig = (ShootingSkillConfig) _skillConfig;
        GameObject bullet = Object.Instantiate(skillConfig.BulletPrefab, _spawnPos.position, _spawnPos.rotation);
    }
}
