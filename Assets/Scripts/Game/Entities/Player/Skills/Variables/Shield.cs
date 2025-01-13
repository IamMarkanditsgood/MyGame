using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : BasicSkill
{
    private SpawnerSkillConfig _config;
    private GameObject _shield;
    private Coroutine _shiledLifeTimer;
    private bool _isActive;

    public override void Init(Transform characterPos)
    {
        base.Init(characterPos);

        _config = (SpawnerSkillConfig) _skillConfig;

        CreateShield();
    }
    public override void OnDisable()
    {
        Object.Destroy(_shield);
        CoroutineServices.instance.StopCoroutine(_shiledLifeTimer);

        base.OnDisable(); 
    }
    public override void ActivateSkill()
    {
        if (!_isActive)
        {
            SwitchShield(true);
            _shiledLifeTimer = CoroutineServices.instance.StartCoroutine(ShieldLifeTimer());
        }
    }
    private void SwitchShield(bool state)
    {
        _shield.SetActive(state);
        _isActive = state;
    }
    private void CreateShield()
    {
        _shield = Object.Instantiate(_config.ObjectPrefab, _characterPos);
        SwitchShield(false);
    }

    private IEnumerator ShieldLifeTimer()
    {
        yield return new WaitForSeconds(_config.GetParameter(SkillParameterType.LifeTime));

        SwitchShield(false);
    }
}
