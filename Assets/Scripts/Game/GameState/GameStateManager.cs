using Game.GameState.GameStates;

namespace Game.GameState
{
	public class GameStateManager
	{
		private AGameState currentGameState;
		
		public void ChangeGameState(AGameState nextState)
		{
			currentGameState.OnGameStateExit();
			currentGameState = nextState;
			currentGameState.OnGameStateEntered();
		}
	}
}