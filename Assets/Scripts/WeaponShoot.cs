using UnityEngine;
using Zenject;

public class WeaponShoot : MonoBehaviour
{
    [Inject] private ObjectPool _objectPool;
    [SerializeField] private Transform _firePoint;
    public void Shoot()
    {
        var bullet = _objectPool.GetPooledObject();
        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = _firePoint.rotation;
        bullet.SetActive(true);
    }

    public void UpdateFirepoint(Transform newFirepoint)
    {
        _firePoint = newFirepoint;
    }
}
