using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private SceneConfig _sceneConfig;
    [SerializeField] private CharacterConfig _characterConfig;

    public SceneConfig SceneConfig => _sceneConfig;
    public CharacterConfig CharacterConfig => _characterConfig; 
}