using System;
using Game.Inputs;

namespace Components.Movement.States
{
	public abstract class AMovableControllerState
	{
		protected InputManager inputManager;
		protected Movable movable;

		public AMovableControllerState(InputManager inputManager, Movable movable)
		{
			this.inputManager = inputManager;
			this.movable = movable;
		}
		
		public virtual void OnStateEntered()
		{
			throw new NotImplementedException();
		}

		public virtual void OnStateExit()
		{
			throw new NotImplementedException();
		}
	}
}