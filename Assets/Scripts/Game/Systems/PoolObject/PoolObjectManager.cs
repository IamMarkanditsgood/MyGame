using System;
using UnityEngine;

[Serializable]
public class PoolObjectManager : MonoBehaviour
{
    public static PoolObjectManager instant;

    [Header("Prefabs")]
    [SerializeField] private BulletController _bulletPref;
    [SerializeField] private MineController _minePref;
    [SerializeField] private BasicEnemyController _enemyPref;
    [Header("Containers")]
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private Transform _minesContainer;
    [SerializeField] private Transform _enemiesContainer;

    private ObjectPool<BulletController> _bullets = new ObjectPool<BulletController>();
    private ObjectPool<MineController> _mines = new ObjectPool<MineController>();
    private ObjectPool<BasicEnemyController> _enemies = new ObjectPool<BasicEnemyController>();

    public ObjectPool<BulletController> Bullets => _bullets;
    public ObjectPool<MineController> Mines => _mines;
    public ObjectPool<BasicEnemyController> Enemies => _enemies;

    public void Init()
    {
        if (instant == null)
        {
            instant = this;
        }
        InitPoolObjects();
    }

    private void InitPoolObjects()
    {
        _bullets.InitializePool(_bulletPref, _bulletContainer);
        _mines.InitializePool(_minePref, _minesContainer);
        _enemies.InitializePool(_enemyPref, _enemiesContainer);
    }
}