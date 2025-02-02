using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private CoroutineServices _coroutineServices;
    [SerializeField] private PoolObjectManager _poolObjectManager;
    [SerializeField] private GamePlayManager _gamePlayManager;

    [SerializeField] private LevelConfig _levelConfig;

    private void Awake()
    {
        _levelCreator.Init(_levelConfig);
    }

    private void Start()
    {
        InitServices();
        InitLevel();
        _gamePlayManager.StartGame();
    }

    private void OnDestroy()
    {
        _gamePlayManager.StopGame();
    }

    private void InitLevel()
    {
        _levelCreator.CreateLevel();
        _gamePlayManager.Init(_levelCreator.Character);
    }

    private void InitServices()
    {
        _poolObjectManager.Init();
        _coroutineServices.Init();
    }
}