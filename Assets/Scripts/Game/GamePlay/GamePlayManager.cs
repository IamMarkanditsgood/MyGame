using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private SwarmController _swarmController;

    private PlayerController _player; 

    public void Init(PlayerController player)
    {
        _player = player;
    }

    public void StartGame()
    {
        _swarmController.StartAI(_player.gameObject.transform);
    }

    public void StopGame()
    {

    }
}
