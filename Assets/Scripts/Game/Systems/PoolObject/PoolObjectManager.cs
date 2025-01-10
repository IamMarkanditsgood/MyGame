using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolObjectManager : MonoBehaviour
{
    public static PoolObjectManager instant;

    [Header("Prefabs")]
    [SerializeField] private BulletManager _bulletPref;
    [Header("Containers")]
    [SerializeField] private Transform _bulletContainer;

    private ObjectPool<BulletManager> _bullets = new ObjectPool<BulletManager>();

    public ObjectPool<BulletManager> Bullets => _bullets;

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
    }
}