using Game.Inputs;
using UniRx;
using UnityEngine;

namespace Components.Movement
{
	[RequireComponent(typeof(Movable))]
	public class MovableController : MonoBehaviour
	{
		[SerializeField] private Movable movable;
		[SerializeField] private InputManager inputManager;

		private AMovableControllerState currentState;

		private void Start()
		{
			currentState = ChangeControllerState(new SolidMovement(inputManager, movable));

			Observable
				.EveryUpdate()
				.Where(_ => Input.GetKeyDown(KeyCode.Space))
				.Subscribe(_ => ChangeControllerState(new SmoothMovement(inputManager, movable)))
				;
		}

		public AMovableControllerState ChangeControllerState(AMovableControllerState newState)
		{
			if (currentState != null) currentState.OnStateExit();
			currentState = newState;
			currentState.OnStateEntered();
			return currentState;
		}
	}
}