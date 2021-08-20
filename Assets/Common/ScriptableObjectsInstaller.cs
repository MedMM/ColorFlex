using Game;
using UnityEngine;
using Zenject;

namespace Common
{
	public class ScriptableObjectsInstaller : MonoInstaller
	{
		[SerializeField] private GameScenes gameScenes;
		[SerializeField] private GameColors gameColors;
		public override void InstallBindings()
		{
			Container.BindInstance(gameScenes).AsSingle().NonLazy();
			Container.BindInstance(gameColors).AsSingle().NonLazy();
		}
	}
}