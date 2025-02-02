using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[Serializable]
public class SwarmController
{
    [SerializeField] private Transform _player; // Гравець
    [SerializeField] private float _teleportDistance = 60f; // Радіус телепорту
    [SerializeField] private List<EnemyGroup> _enemyGroups = new List<EnemyGroup>(); // Групи ворогів

    private Dictionary<EnemyType, List<BasicEnemyController>> _enemiesByType = new Dictionary<EnemyType, List<BasicEnemyController>>();

    private List<Coroutine> _groupUpdate = new List<Coroutine>();

    public void StartAI(Transform player)
    {
        _player = player;
        for(int i = 0;i < 5; i++)
        {
            CreateEnemy();
        }

        StartEnemyGroupsUpdate();
    }

    private void StartEnemyGroupsUpdate()
    {
        for (int i = 0; i < _enemyGroups.Count; i++)
        {
            _enemiesByType[_enemyGroups[i].EnemyType] = new List<BasicEnemyController>();
            CoroutineServices.instance.StartRoutine(UpdateEnemyGroup(_enemyGroups[i]));
        }
    }

    private void CreateEnemy()
    {
        BasicEnemyController enemy = PoolObjectManager.instant.Enemies.GetComponent();

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
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * (_teleportDistance / 2);
        randomDirection.y = 0; // Вирівнюємо по горизонталі

        Vector3 spawnPosition = _player.position + randomDirection;
        spawnPosition.y = _player.position.y; // Призначаємо ту ж висоту, що у гравця

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
                foreach (var enemy in _enemiesByType[group.EnemyType].ToList()) // Копія списку, щоб уникнути помилок при видаленні ворогів
                {
                    if (enemy == null)
                    {
                        _enemiesByType[group.EnemyType].Remove(enemy);
                        continue;
                    }

                    float distance = Vector3.Distance(enemy.transform.position, playerPos);

                    if (distance > _teleportDistance)
                    {
                        enemy.TeleportToRandomPosition(playerPos, group.UpdateDistance);
                    }
                    else if (distance <= group.UpdateDistance)
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
    public float UpdateDistance = 50f; // Дальність оновлення маршруту
}