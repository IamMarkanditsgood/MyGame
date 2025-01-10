using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Amunition/Bullet", order = 1)]
public class BulletConfig : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;
    [SerializeField] private float _basickBulletDamage;

    public Mesh Mesh => _mesh;
    public Material Material => _material;  
    public float BasickBulletDamage => _basickBulletDamage;
}
