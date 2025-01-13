using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : BasicSkill
{
    private SpawnerSkillConfig _config;
    private GameObject _drone;
    private Coroutine _droneLifeTimer;
    private bool _isActive;

    public override void Init(Transform characterPos)
    {
        base.Init(characterPos);

        _config = (SpawnerSkillConfig)_skillConfig;

        CreateDrone();
    }
    public override void OnDisable()
    {
        Object.Destroy(_drone);
        CoroutineServices.instance.StopCoroutine(_droneLifeTimer);

        base.OnDisable();
    }
    public override void ActivateSkill()
    {
        if (!_isActive)
        {
            SwitchDrone(true);
            _drone.transform.position = _characterPos.position;
            _droneLifeTimer = CoroutineServices.instance.StartCoroutine(DroneLifeTimer());
        }
    }
    private void SwitchDrone(bool state)
    {
        _drone.SetActive(state);
        _isActive = state;
    }
    private void CreateDrone()
    {
        _drone = Object.Instantiate(_config.ObjectPrefab);
        SwitchDrone(false);
    }

    private IEnumerator DroneLifeTimer()
    {
        yield return new WaitForSeconds(_config.GetParameter(SkillParameterType.LifeTime));

        SwitchDrone(false);
    }
}
