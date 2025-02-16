using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyType _enemyType;
    [SerializeField] private NavMeshAgent _agent;

    public EnemyType Type => _enemyType;

    private void OnEnable()
    {
        _agent.enabled = true;
    }

    private void OnDisable()
    {
        _agent.enabled = false;
    }

    public void UpdateTarget(Vector3 targetPosition)
    {
        if (_agent != null && _agent.isOnNavMesh)
        {
            _agent.SetDestination(targetPosition);
        }
    }

    public void TeleportToRandomPosition(Vector3 playerPosition, float innerRadius, float outerRadius, int maxAttempts = 10)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized;

            float randomDistance = Random.Range(innerRadius, outerRadius);
            Vector3 newPosition = playerPosition + randomDirection * randomDistance;
            newPosition.y = 0;

            if (NavMesh.SamplePosition(newPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                _agent.Warp(hit.position);
                return; 
            }
        }
        Debug.LogWarning("Не вдалося знайти підходящу позицію для телепортації!");
    }
}