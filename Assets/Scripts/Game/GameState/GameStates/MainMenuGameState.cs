using UnityEngine;

namespace Game.GameState.GameStates
{
	public class MainMenuGameState : AGameState
	{
		public override void OnGameStateEntered()
		{
			Debug.Log("Main Menu State Entered!");
		}

		public override void OnGameStateExit()
		{
			Debug.Log("Main Menu State Exit!");
		}
	}
}