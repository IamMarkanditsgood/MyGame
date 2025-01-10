using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : BasicShootingSkill
{
    public override void Shoot()
    {
        ShootingSkillConfig skillConfig = (ShootingSkillConfig) _skillConfig;

        BulletManager bullet = PoolObjectManager.instant.Bullets.GetComponent();

        bullet.gameObject.transform.position = _spawnPos.position;
        bullet.gameObject.transform.rotation = _spawnPos.rotation;

        BulletData bulletData = SetBulletData(skillConfig);
        bullet.Shot(bulletData, skillConfig.BulletConfig);
    }

    private BulletData SetBulletData(ShootingSkillConfig skillConfig)
    {
        BulletData bulletData = new BulletData();

        bulletData.LifeTime = skillConfig.GetParameter(SkillParameterType.LifeTime);      
        bulletData.Speed = skillConfig.GetParameter(SkillParameterType.Speed);
        bulletData.Damage = skillConfig.GetParameter(SkillParameterType.Damage) + skillConfig.BulletConfig.BasickBulletDamage;

        return bulletData;
    }
}
