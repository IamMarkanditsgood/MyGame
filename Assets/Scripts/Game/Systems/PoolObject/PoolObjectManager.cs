using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolObjectManager : MonoBehaviour
{
    public static PoolObjectManager instant;

    [Header("Prefabs")]
    [SerializeField] private BulletController _bulletPref;
    [SerializeField] private MineController _minePref;

    [Header("Containers")]
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private Transform _minesContainer;
    [SerializeField] private Transform _enemiesContainer;

    private ObjectPool<BulletController> _bullets = new ObjectPool<BulletController>();
    private ObjectPool<MineController> _mines = new ObjectPool<MineController>();
    
    public ObjectPool<BulletController> Bullets => _bullets;
    public ObjectPool<MineController> Mines => _mines;

    public List<EnemiesPoolObject> enemies = new List<EnemiesPoolObject>();

    [Serializable]
    public class EnemiesPoolObject
    {
        public EnemyType enemyType;
        public BasicEnemyController enemyPref;
        public ObjectPool<BasicEnemyController> enemies = new ObjectPool<BasicEnemyController>();
    }

    public void Init()
    {
        if (instant == null)
        {
            instant = this;
        }
        InitPoolObjects();
    }

    public BasicEnemyController GetEnemy(EnemyType enemyType)
    {
        foreach (var enemyPool in enemies)
        {
            if(enemyType == enemyPool.enemyType)
            {
                BasicEnemyController enemy = enemyPool.enemies.GetComponent();
                return enemy;
            }
        }
        Debug.LogWarning("No this type of enemy");
        return null;
    }

    private void InitPoolObjects()
    {
        _bullets.InitializePool(_bulletPref, _bulletContainer);
        _mines.InitializePool(_minePref, _minesContainer);
        InitEnemies();
    }

    private void InitEnemies()
    {
        foreach(var enemyPool in enemies)
        {
            enemyPool.enemies.InitializePool(enemyPool.enemyPref, _enemiesContainer);
        }
    }
}