using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpdateDirection : MonoBehaviour
{
    [Inject] private PlayerDirection _playerDirection;
    [SerializeField] private SpriteRenderer _weaponSprite;
    [SerializeField] private Transform[] _firepoints;
    private WeaponShoot _weaponShoot;

    private void Awake()
    {
        _weaponShoot = GetComponent<WeaponShoot>();
    }

    private void Start()
    {
        CustomEvents.OnPlayerChangeDirection += UpdateView;
    }

    private void OnEnable()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _weaponSprite.flipY = _playerDirection.IsRight;
        var newFirepoint = !_playerDirection.IsRight ? _firepoints[0] : _firepoints[1];
        _weaponShoot.UpdateFirepoint(newFirepoint);
    }

    private void OnDestroy()
    {
        CustomEvents.OnPlayerChangeDirection -= UpdateView;
    }
}
