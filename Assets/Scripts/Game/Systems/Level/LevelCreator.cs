using Cinemachine;
using System;
using UnityEngine;

[Serializable]
public class LevelCreator
{
    [SerializeField] private SceneCreator _sceneCreator;
    [SerializeField] private CharacterCreator _characterCreator;

    [SerializeField] private CinemachineVirtualCamera _characterCamera;

    private LevelConfig _levelConfig;

    private PlayerController _character;
    private GameObject _scene;

    public void Init(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;

        _sceneCreator.Init(_levelConfig.SceneConfig);
        _characterCreator.Init(_levelConfig.CharacterConfig);
    }

    public void CreateLevel()
    {
        _scene = _sceneCreator.CreateScene();
        _character = _characterCreator.CreateCharacter();

        SetCamera(_character);
    }

    private void SetCamera(PlayerController character)
    {
        _characterCamera.LookAt = character.gameObject.transform;
        _characterCamera.Follow = character.gameObject.transform;
    }
}