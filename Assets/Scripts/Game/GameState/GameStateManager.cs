using Game.GameState.GameStates;

namespace GameState
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