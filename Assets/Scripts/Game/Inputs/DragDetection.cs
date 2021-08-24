using System;
using UnityEngine;
using UniRx;

namespace Game.Inputs
{
	public class DragDetection
	{
		private bool isTouching;
		private Vector2 startPosition;
		public event Action<Vector2> OnDrag;

		public DragDetection(InputManager inputManager)
		{
			inputManager.OnStartTouch += OnStartTouch;
			inputManager.OnEndTouch += OnEndTouch;

			Observable
				.EveryUpdate()
				.Where(_ => isTouching)
				.Subscribe(_ => OnTouching(inputManager));
		}

		private void OnStartTouch(Vector2 position, float time)
		{
			isTouching = true;
			startPosition = position;
		}

		private void OnEndTouch(Vector2 position, float time)
			=> isTouching = false;

		private void OnTouching(InputManager inputManager)
			=> OnDrag?.Invoke(startPosition - inputManager.PrimaryPosition());
	}
}