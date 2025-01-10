using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private PoolObjectManager _poolObjectManager;

    [SerializeField] private LevelConfig _levelConfig;

    private void Awake()
    {
        _levelCreator.Init(_levelConfig);
    }

    private void Start()
    {
        _poolObjectManager.InitPoolObjects();
        _levelCreator.CreateLevel();  
    }
}