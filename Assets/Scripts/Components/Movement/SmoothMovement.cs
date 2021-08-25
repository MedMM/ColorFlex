﻿using Game.Inputs;
using UnityEngine;

namespace Components.Movement
{
	public class SmoothMovement : AMovableControllerState
	{
		private float currentRotation;
		
		public SmoothMovement(InputManager inputManager, Movable movable)
			: base(inputManager, movable)
		{
		}

		public override void OnStateEntered()
		{
			inputManager.Drag.OnDrag += OnDrag;
			inputManager.OnStartTouch += OnStartTouch;
		}

		public override void OnStateExit()
		{
			inputManager.Drag.OnDrag -= OnDrag;
			inputManager.OnStartTouch -= OnStartTouch;
		}

		private void OnStartTouch(Vector2 position, float time) 
			=> currentRotation = movable.Rotation;

		private void OnDrag(Vector2 dragPosition)
		{
			var rotation = currentRotation + dragPosition.x * -6f;
			movable.Rotation = rotation;
		}
	}
}