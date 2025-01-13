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

    public PlayerController Character { get; set; }
    public GameObject Scene { get; set; }

    public void Init(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;

        _sceneCreator.Init(_levelConfig.SceneConfig);
        _characterCreator.Init(_levelConfig.CharacterConfig);
    }

    public void CreateLevel()
    {
        Scene = _sceneCreator.CreateScene();
        Character = _characterCreator.CreateCharacter();

        SetCamera(Character);
    }

    private void SetCamera(PlayerController character)
    {
        _characterCamera.LookAt = character.gameObject.transform;
        _characterCamera.Follow = character.gameObject.transform;
    }
}