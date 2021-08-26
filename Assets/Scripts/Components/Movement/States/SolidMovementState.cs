using Game.Inputs;
using UnityEngine;

namespace Components.Movement.States
{
	public class SolidMovementState : AMovableControllerState
	{
		public SolidMovementState(InputManager inputManager, Movable movable) 
			: base(inputManager, movable)
		{
		}
		
		public override void OnStateEntered()
		{
			inputManager.Swipes.OnSwipeLeft += OnSwipeLeft;
			inputManager.Swipes.OnSwipeRight += OnSwipeRight;
			inputManager.Swipes.OnSwipeDown += OnSwipeDown;
		}

		private void OnSwipeDown()
		{
			movable.Dash(new Vector2(0, -15f), 1);
		}

		public override void OnStateExit()
		{
			inputManager.Swipes.OnSwipeLeft -= OnSwipeLeft;
			inputManager.Swipes.OnSwipeRight -= OnSwipeRight;
			inputManager.Swipes.OnSwipeDown -= OnSwipeDown;

		}
		
		private void OnSwipeRight() 
			=> movable.Rotate(90);

		private void OnSwipeLeft() 
			=> movable.Rotate(-90);
	}
}