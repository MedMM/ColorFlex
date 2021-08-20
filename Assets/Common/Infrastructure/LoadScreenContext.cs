using Loaders;
using UnityEngine;
using Zenject;

namespace Common.Infrastructure
{
    public class LoadScreenContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameLoader = new GameObject().AddComponent<GameLoader>();
            Container.BindInstance(gameLoader).AsSingle().NonLazy();
        }
    }
}
