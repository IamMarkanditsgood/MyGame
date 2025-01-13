using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BasicShootingSkill
{
    public override void Shoot()
    {
        ShootingSkillConfig skillConfig = (ShootingSkillConfig)_skillConfig;

        int pelletCount = Mathf.RoundToInt(skillConfig.GetParameter(SkillParameterType.Count)); 
        float spreadAngle = skillConfig.GetParameter(SkillParameterType.SpreadAngle); 
        float maxDelay = skillConfig.GetParameter(SkillParameterType.Delay); 

        for (int i = 0; i < pelletCount; i++)
        {
         
            CoroutineServices.instance.StartCoroutine(ShootPelletWithDelay(spreadAngle, maxDelay, skillConfig));
        }
    }

    private IEnumerator ShootPelletWithDelay(float spreadAngle, float maxDelay, ShootingSkillConfig skillConfig)
    {
        // Випадкова затримка для дробинки
        float delay = Random.Range(0, maxDelay);
        yield return new WaitForSeconds(delay);

        BulletController bullet = PoolObjectManager.instant.Bullets.GetComponent();

        bullet.gameObject.transform.position = _spawnPos.position;

        // Вираховуємо розкид тільки в межах кута SpreadAngle
        float angleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
        Quaternion spreadRotation = Quaternion.Euler(0, angleOffset, 0); // Розворот по Y (горизонтальна площина)

        // Обчислюємо напрямок із розкидом
        Vector3 spreadDirection = spreadRotation * _spawnPos.forward;

        // Задаємо напрямок і обертання для кулі
        bullet.gameObject.transform.rotation = Quaternion.LookRotation(spreadDirection);

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
