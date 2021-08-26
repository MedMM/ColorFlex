using Signals.GameStatesChanges;
using Zenject;

namespace Common.Infrastructure
{
	public class BootstrapInstaller : MonoInstaller
	{
		// ReSharper disable Unity.PerformanceAnalysis
		public override void InstallBindings()
		{
			BindSignals();
		}

		private void BindSignals()
		{
			SignalBusInstaller.Install(Container);
			Container.DeclareSignal<GameStateClassicPlatform>();
		}
	}
	
}
