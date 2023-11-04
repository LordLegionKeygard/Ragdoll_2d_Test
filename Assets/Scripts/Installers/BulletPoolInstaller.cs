using UnityEngine;
using Zenject;

public class BulletPoolInstaller : MonoInstaller
{
    [SerializeField] private ObjectPool _objectPool;
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool>().FromInstance(_objectPool).AsSingle();
    }
}