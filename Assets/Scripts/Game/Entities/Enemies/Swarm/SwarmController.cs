using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[Serializable]
public class SwarmController
{
    [SerializeField] private Transform _player; // Гравець
    [SerializeField] private float _teleportDistance = 60f; // Радіус телепорту
    [SerializeField] private float _inerSpawnRadius;
    [SerializeField] private float _outerSpawnRadius;
    [SerializeField] private List<EnemyGroup> _enemyGroups = new List<EnemyGroup>(); // Групи ворогів

    private Dictionary<EnemyType, List<BasicEnemyController>> _enemiesByType = new Dictionary<EnemyType, List<BasicEnemyController>>();

    private List<Coroutine> _groupUpdate = new List<Coroutine>();

    public void StartAI(Transform player)
    {
        _player = player;
        //I will need to do another
        for(int i = 0;i < 150; i++)
        {
            CreateEnemy(EnemyType.SpeedRunner);
        }

        StartEnemyGroupsUpdate();
    }

    public void StopAI()
    {
        foreach (Coroutine group in _groupUpdate)
        {
            CoroutineServices.instance.StopCoroutine(group);
        }
    }

    private void StartEnemyGroupsUpdate()
    {
        for (int i = 0; i < _enemyGroups.Count; i++)
        {
            Coroutine newGroupUpdate = CoroutineServices.instance.StartRoutine(UpdateEnemyGroup(_enemyGroups[i]));
            _groupUpdate.Add(newGroupUpdate);
        }
    }

    private void CreateEnemy(EnemyType enemyType)
    {
        BasicEnemyController enemy = PoolObjectManager.instant.GetEnemy(enemyType);

        if (enemy != null)
        {
            Vector3 spawnPosition = GetRandomPositionAroundPlayer();
            enemy.gameObject.transform.position = spawnPosition;
            enemy.gameObject.SetActive(true);

            RegisterEnemy(enemy);
        }
    }

    private Vector3 GetRandomPositionAroundPlayer()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere.normalized;

        float randomDistance = UnityEngine.Random.Range(_inerSpawnRadius, _outerSpawnRadius);
        Vector3 spawnPosition = _player.position + randomDirection * randomDistance;

        spawnPosition.y = _player.position.y;

        return spawnPosition;
    }

    private void RegisterEnemy(BasicEnemyController enemy)
    {
        if (!_enemiesByType.ContainsKey(enemy.Type))
        {
            _enemiesByType[enemy.Type] = new List<BasicEnemyController>();
        }
        _enemiesByType[enemy.Type].Add(enemy);
    }

    private IEnumerator UpdateEnemyGroup(EnemyGroup group)
    {
        while (true)
        {
            Vector3 playerPos = _player.position;

            if (_enemiesByType.ContainsKey(group.EnemyType))
            {
                foreach (BasicEnemyController enemy in _enemiesByType[group.EnemyType]) // Копія списку, щоб уникнути помилок при видаленні ворогів
                {
                    
                    if (enemy == null)
                    {
                        _enemiesByType[group.EnemyType].Remove(enemy);
                        continue;
                    }

                    float distance = Vector3.Distance(enemy.transform.position, playerPos);
                    
                    if (distance > _teleportDistance)
                    {
                        enemy.TeleportToRandomPosition(playerPos, _inerSpawnRadius, _outerSpawnRadius);
                    }
                    else if (distance <= group.AttackRadius)
                    {
                        
                        enemy.UpdateTarget(playerPos);
                    }
                }
            }

            yield return new WaitForSeconds(group.UpdateRate);
        }
    }
}

[Serializable]
public class EnemyGroup
{
    public EnemyType EnemyType; // Тип ворога
    public float UpdateRate = 0.5f; // Як часто оновлювати ціль
    public float AttackRadius = 50f; // Дальність оновлення маршруту
}