using Game.GameState;
using Zenject;

namespace Common.Infrastructure
{
	public class BootstrapInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<GameStateManager>().AsSingle().NonLazy();
		}
	}
}
