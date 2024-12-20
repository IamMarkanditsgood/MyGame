using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "ScriptableObjects/SceneConfig", order = 1)]
public class SceneConfig : ScriptableObject
{
    [SerializeField] private GameObject _scenePrefab;

    public GameObject ScenePrefab => _scenePrefab;
}
