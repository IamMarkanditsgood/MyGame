using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    private PlayerSkillsManager _playerSkillsManager = new PlayerSkillsManager();
    private PlayerInputSystem _playerInputSystem = new PlayerInputSystem();
    private PlayerMovementManager _playerMovementManager = new PlayerMovementManager();
    private PlayerRotationManager _playerRotationManager = new PlayerRotationManager();
    private PlayerDataManager _characterDataManager = new PlayerDataManager();
    private PlayerParametersManager _characterParametersManager = new PlayerParametersManager();

    [SerializeField] private CharacterData _characterData;
    private CharacterConfig _characterConfig;

    

    private void Update()
    {
        _playerInputSystem.CheckInput();
        _playerMovementManager.UpdateMovementDirection();
    }

    private void OnDestroy()
    {
        Unsubscribe();
        DisableManagers();
    }
    private void OnDisable()
    {
        Unsubscribe();
        DisableManagers();
    }

    public void Init(CharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;

        _characterData = _characterDataManager.ConfigureCharacterData(_characterConfig,_characterData);

        InitManagers();
        Subscribe();
    }

    private void InitManagers()
    {
        _playerInputSystem.Init();
        _playerMovementManager.Init(_characterController, _characterData.GetParameter(PlayerParameterTypes.MovementSpeed), gameObject.transform);
        _playerRotationManager.Init(gameObject.transform, _characterData.GetParameter(PlayerParameterTypes.RotationSpeed));
        _characterParametersManager.Init(ref _characterData);
        _playerSkillsManager.Init(_characterConfig.skillsCollection, _characterData.Skills, gameObject.transform, _characterData.ShootingPos);
    }
    private void DisableManagers()
    {
        _playerSkillsManager.Disable();
        _characterParametersManager.Disable();
    }

    private void Subscribe()
    {
        InputEvents.OnMovementPressed += MovePlayer;
        InputEvents.OnMouseMoved += RotatePlayer;
        InputEvents.OnSkillPressed += UseSkill;
    }

    private void Unsubscribe()
    {
        InputEvents.OnMovementPressed -= MovePlayer;
        InputEvents.OnMouseMoved -= RotatePlayer;
        InputEvents.OnSkillPressed -= UseSkill;
    }

    private void MovePlayer(Vector2 movementDirection)
    {
        _playerMovementManager.MoveCharacter(movementDirection);
    }

    private void RotatePlayer(Vector2 movementDirection)
    {
        _playerRotationManager.Rotate(movementDirection);
    }
    private void UseSkill(int skillIndex)
    {
        _playerSkillsManager.UseSkill(skillIndex);
    }
}