using System;
using System.Collections;
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

    private ObjectPool<BulletController> _bullets = new ObjectPool<BulletController>();
    private ObjectPool<MineController> _mines = new ObjectPool<MineController>();

    public ObjectPool<BulletController> Bullets => _bullets;
    public ObjectPool<MineController> Mines => _mines;

    private void Start()
    {
        if (instant == null)
        {
            instant = this;
        }
    }

    public void InitPoolObjects()
    {
        _bullets.InitializePool(_bulletPref, _bulletContainer);
        _mines.InitializePool(_minePref, _minesContainer);
    }
}