using UnityEngine;
using Zenject;

public class PlayerDirectionInstaller : MonoInstaller
{
    [SerializeField] private PlayerDirection _playerDirection;
    public override void InstallBindings()
    {
        Container.Bind<PlayerDirection>().FromInstance(_playerDirection).AsSingle();
    }
}