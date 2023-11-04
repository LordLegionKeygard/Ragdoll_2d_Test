using System.Collections;
using UnityEngine;

public class ShootTimer : MonoBehaviour
{
    private WeaponShoot _weaponShoot;

    private void Awake()
    {
        _weaponShoot = GetComponent<WeaponShoot>();
    }

    private void Start()
    {
        StartCoroutine(nameof(ShootCoroutine));
    }


    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _weaponShoot.Shoot();
        StartCoroutine(nameof(ShootCoroutine));
    }
}
