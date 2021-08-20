namespace Game.GameState.GameStates
{
	public abstract class AGameState
	{
		public abstract void OnGameStateEntered();
		
		public abstract void OnGameStateExit();
	}
}