using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : BasicSkill
{
    private SpawnerSkillConfig _config;
    private List<GameObject> _swords = new List<GameObject>();
    private Coroutine _lifeTimer;

    private bool _isActive;

    public override void Init(Transform characterPos)
    {
        base.Init(characterPos);

        _config = (SpawnerSkillConfig)_skillConfig;

        CreateSwords();
    }
    public override void OnDisable()
    {
        DestroySwords();
        CoroutineServices.instance.StopCoroutine(_lifeTimer);

        base.OnDisable();
    }
    public override void ActivateSkill()
    {
        if (!_isActive)
        {
            SwitchSwords(true);
            _lifeTimer = CoroutineServices.instance.StartCoroutine(LifeTimer());
        }
    }

    private void CreateSwords()
    {
        float angleStep = 360f / _skillConfig.GetParameter(SkillParameterType.Count);

        for (int i = 0; i < _skillConfig.GetParameter(SkillParameterType.Count); i++)
        {
            float angle = i * angleStep;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 spawnPosition = new Vector3(
                _characterPos.position.x + Mathf.Cos(radians) * _skillConfig.GetParameter(SkillParameterType.Distance),
                _characterPos.position.y, // Мечі розташовані на рівні гравця
                _characterPos.position.z + Mathf.Sin(radians) * _skillConfig.GetParameter(SkillParameterType.Distance)
            );

            SpawnerSkillConfig config = (SpawnerSkillConfig)_skillConfig;
            GameObject sword = Object.Instantiate(config.ObjectPrefab, spawnPosition, Quaternion.identity);
            sword.transform.SetParent(_characterPos);
            _swords.Add(sword);
            SwitchSwords(false);
        }
    }
    private void DestroySwords()
    {
        foreach(var sword in _swords)
        {
            Object.Destroy(sword);
        }
    }
    private void SwitchSwords(bool state)
    {
        _isActive = state;
        foreach (var sword in _swords)
        {
            sword.SetActive(state);
        }
    }
    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(_config.GetParameter(SkillParameterType.LifeTime));

        SwitchSwords(false);
    }
}
