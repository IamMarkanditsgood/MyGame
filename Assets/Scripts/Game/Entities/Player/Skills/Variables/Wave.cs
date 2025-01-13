using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : BasicSkill
{
    private LayerMask enemyLayer;
    public override void ActivateSkill()
    {
        enemyLayer = enemyLayer = 1 << Mathf.FloorToInt(_skillConfig.GetParameter(SkillParameterType.EnemyLayerIndex));
        Collider[] hitColliders = Physics.OverlapSphere(_characterPos.position, _skillConfig.GetParameter(SkillParameterType.FieldRadius), enemyLayer);

        foreach (Collider hitCollider in hitColliders)
        {

            Vector3 pushDirection = (hitCollider.transform.position - _characterPos.position).normalized;
            //To do
        }
    }
}
