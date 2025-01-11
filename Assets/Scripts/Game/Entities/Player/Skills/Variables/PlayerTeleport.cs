using UnityEngine;

public class PlayerTeleport : BasicSkill
{
    private CharacterController _playerController;
    private Vector3 _playerDirection;

    public override void Init(Transform characterPos)
    {
        base.Init(characterPos);
        _playerController = characterPos.GetComponent<CharacterController>();
        Subscribe();
    }
    public override void OnDisable()
    {
        base.OnDisable();
        Unsubscribe();
    }
    private void Subscribe()
    {
        PlayerEvents.OnDirectionModified += ModifyDirection;
    }
    private void Unsubscribe() 
    {
        PlayerEvents.OnDirectionModified -= ModifyDirection;
    }
    public override void ActivateSkill()
    {
        if (_playerController == null)
        {
            Debug.LogWarning("Player controller is not set.");
            return;
        }

        Vector3 teleportPosition;
        if (_playerDirection == Vector3.zero)
        {
            teleportPosition = _playerController.transform.position - _playerController.transform.forward * _skillConfig.GetParameter(SkillParameterType.Distance);
        }
        else
        {
            teleportPosition = _playerController.transform.position + _playerDirection.normalized * _skillConfig.GetParameter(SkillParameterType.Distance);
        }

        if (_playerController.enabled) 
        {
            _playerController.enabled = false; 
            _playerController.transform.position = teleportPosition;
            _playerController.enabled = true; 
        }
        else
        {
            Debug.LogWarning("CharacterController is disabled.");
        }
    }

    private void ModifyDirection(Vector3 newDirection)
    {
        _playerDirection = newDirection;
    }
}
