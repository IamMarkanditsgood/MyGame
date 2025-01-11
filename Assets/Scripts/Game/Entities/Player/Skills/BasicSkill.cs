using System;
using System.Collections;
using UnityEngine;

[Serializable]
public abstract class BasicSkill
{
    [SerializeField] protected BasicSkillConfig _skillConfig;

    protected bool _isRecharged = true;
    protected Transform _characterPos;

    private Coroutine _rechargeSkillTimer;

    public BasicSkillConfig SkillConfig { get { return _skillConfig; } set { _skillConfig = value; } }

    public void StopCoroutines()
    {
        if (_rechargeSkillTimer != null)
        {
            CoroutineServices.instance.StopCoroutine(_rechargeSkillTimer);
        }
    }

    public abstract void ActivateSkill();


    public virtual void Init(Transform characterPos)
    {
        _characterPos = characterPos;
    }
    public virtual void OnDisable()
    {
    }

    public virtual void UseSkill()
    {
        if (!_isRecharged)
        {
            Debug.Log($"Skill {_skillConfig.Type} is recharged");
            return;
        }

        ActivateSkill();
        StartRecharge();
    }

    public virtual void StartRecharge()
    {
        _isRecharged = false;
        _rechargeSkillTimer = CoroutineServices.instance.StartCoroutine(RechargeTimer());
    }
    private IEnumerator  RechargeTimer()
    {
        float rechargeTime = _skillConfig.GetParameter(SkillParameterType.Recharge);
        float elapsedTime = 0f;

        while (elapsedTime < rechargeTime)
        {
            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

        _isRecharged = true;
        CoroutineServices.instance.StopCoroutine(_rechargeSkillTimer);
    }
}