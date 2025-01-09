using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private PlayerSkillsManager _playerSkillsManager;

    private PlayerInputSystem _playerInputSystem = new PlayerInputSystem();
    private PlayerMovementManager _playerMovementManager = new PlayerMovementManager();
    private PlayerRotationManager _playerRotationManager = new PlayerRotationManager();
    private CharacterDataManager _characterDataManager = new CharacterDataManager();
    private PlayerParametersManager _characterParametersManager = new PlayerParametersManager();

    private CharacterData _characterData = new CharacterData();
    private CharacterConfig _characterConfig;

    private void Start()
    {
        Subscribe();
    }

    private void Update()
    {
        _playerInputSystem.CheckInput();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    public void Init(CharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;

        _characterData = _characterDataManager.ConfigureCharacterData(_characterConfig);

        InitManagers();
    }

    private void InitManagers()
    {
        _playerInputSystem.Init();
        _playerMovementManager.Init(_characterController, _characterData.GetParameter(PlayerParameterTypes.MovementSpeed), gameObject.transform);
        _playerRotationManager.Init(gameObject.transform, _characterData.GetParameter(PlayerParameterTypes.RotationSpeed));
        _characterParametersManager.Init(ref _characterData);
        _playerSkillsManager.Init(_characterConfig.SkillsCollection, _characterData.Skills);
    }

    private void Subscribe()
    {
        InputEvents.OnMovementPressed += MovePlayer;
        InputEvents.OnMouseMoved += RotatePlayer;
    }

    private void Unsubscribe()
    {
        InputEvents.OnMovementPressed -= MovePlayer;
        InputEvents.OnMouseMoved -= RotatePlayer;

        _characterParametersManager.UnSubscribe();
    }

    private void MovePlayer(Vector2 movementDirection)
    {
        _playerMovementManager.MoveCharacter(movementDirection);
    }

    private void RotatePlayer(Vector2 movementDirection)
    {
        _playerRotationManager.Rotate(movementDirection);
    }
}