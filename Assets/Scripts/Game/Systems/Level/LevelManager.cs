using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private PoolObjectManager _poolObjectManager;
    [SerializeField] private GamePlayManager _gamePlayManager;

    [SerializeField] private LevelConfig _levelConfig;

    private void Awake()
    {
        _levelCreator.Init(_levelConfig);
    }

    private void Start()
    {
        InitManagers();
        _gamePlayManager.StartGame();
    }

    private void OnDestroy()
    {
        _gamePlayManager.StopGame();
    }

    private void InitManagers()
    {
        _poolObjectManager.InitPoolObjects();
        _levelCreator.CreateLevel();
        _gamePlayManager.Init(_levelCreator.Character);
    }
}