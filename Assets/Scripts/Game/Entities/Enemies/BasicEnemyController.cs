using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyType _enemyType;

    public EnemyType Type => _enemyType;
}