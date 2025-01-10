using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class BulletData
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    public float LifeTime { get { return _lifeTime; } set { _lifeTime = value; } }
    public float Damage { get { return _damage; } set { _damage = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
}