using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyType _enemyType;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;

    public EnemyType Type => _enemyType;

    public void UpdateTarget(Vector3 targetPosition)
    {
        if (_agent != null && _agent.isOnNavMesh)
        {
            _agent.SetDestination(targetPosition);
        }
    }

    public void TeleportToRandomPosition(Vector3 playerPosition, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0; // �����������, �� ����� �� �������� � ������
        Vector3 newPosition = playerPosition + randomDirection;

        if (UnityEngine.AI.NavMesh.SamplePosition(newPosition, out UnityEngine.AI.NavMeshHit hit, radius, UnityEngine.AI.NavMesh.AllAreas))
        {
            _agent.Warp(hit.position);
        }
    }
}