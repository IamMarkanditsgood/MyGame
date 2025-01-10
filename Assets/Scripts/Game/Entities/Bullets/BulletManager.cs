using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private BulletData _bulletData;
    [SerializeField] private BulletConfig _bulletConfig;

    private Coroutine _lifeTimer;
    private bool _isActive;

    private void FixedUpdate()
    {
        if (_isActive)
        {
            MoveBullet();
        }
    }
    private void OnEnable()
    {
        _isActive = true;
    }
    private void OnDisable()
    {
        _isActive = false;
    }
   
    public void Shot(BulletData bulletData, BulletConfig bulletConfig)
    {
        _bulletData = bulletData;
        _bulletConfig = bulletConfig;
        ConfigureBullet();
        _lifeTimer = CoroutineServices.instance.StartCoroutine(LifeTimer());
    }

    private void ConfigureBullet()
    {
        gameObject.GetComponent<MeshFilter>().mesh = _bulletConfig.Mesh;
        gameObject.GetComponent<MeshRenderer>().material = _bulletConfig.Material;
    }

    private void MoveBullet()
    {
        transform.position += transform.forward * _bulletData.Speed * Time.fixedDeltaTime;
    }

    private IEnumerator LifeTimer()
    {
        float rechargeTime = _bulletData.LifeTime;
        float elapsedTime = 0f;

        while (elapsedTime < rechargeTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PoolObjectManager.instant.Bullets.DisableComponent(this);
        CoroutineServices.instance.StopCoroutine(_lifeTimer);

    }
}
