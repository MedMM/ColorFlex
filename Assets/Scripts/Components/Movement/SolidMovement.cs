using Game.Inputs;

namespace Components.Movement
{
	public class SolidMovement : AMovableControllerState
	{
		public SolidMovement(InputManager inputManager, Movable movable) 
			: base(inputManager, movable)
		{
		}
		
		public override void OnStateEntered()
		{
			inputManager.Swipes.OnSwipeLeft += OnSwipeLeft;
			inputManager.Swipes.OnSwipeRight += OnSwipeRight;
		}

		public override void OnStateExit()
		{
			inputManager.Swipes.OnSwipeLeft -= OnSwipeLeft;
			inputManager.Swipes.OnSwipeRight -= OnSwipeRight;
		}
		
		private void OnSwipeRight() 
			=> movable.Rotate(90);

		private void OnSwipeLeft() 
			=> movable.Rotate(-90);
	}
}