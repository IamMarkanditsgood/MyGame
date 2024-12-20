using System;
using UnityEngine;

[Serializable]
public class SceneCreator
{
    [SerializeField] private Transform _sceneSpawnPos;

    private SceneConfig _sceneConfig;

    public void Init(SceneConfig sceneConfig)
    {
        _sceneConfig = sceneConfig;
    }

    public GameObject CreateScene()
    {
        GameObject newScene = UnityEngine.Object.Instantiate(_sceneConfig.ScenePrefab);
        newScene.transform.position = _sceneSpawnPos.position;
        return newScene;
    }
}
