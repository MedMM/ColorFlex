using System;
using UnityEngine;

namespace Game.Inputs
{
	public class SwipeDetection
	{
		private float minimumDistance = 0.2f;
		private float maximumTime = 1f;
		private Vector2 startPosition;
		private float startTime;
		private Vector2 endPosition;
		private float endTime;

		public event Action OnSwipeLeft;
		public event Action OnSwipeRight;
		public event Action OnSwipeUp;
		public event Action OnSwipeDown;
		public event Action<Vector2> OnSwipeDrag;

		public SwipeDetection(InputManager inputManager,
			ref float minimumDistance,
			ref float maximumTime
		)
		{
			inputManager.OnStartTouch += SwipeStart;
			inputManager.OnEndTouch += SwipeEnd;

			this.minimumDistance = minimumDistance;
			this.maximumTime = maximumTime;
		}

		private void SwipeStart(Vector2 position, float time)
		{
			startPosition = position;
			startTime = time;
		}

		private void SwipeEnd(Vector2 position, float time)
		{
			endPosition = position;
			endTime = time;
			DetectSwipe();
		}

		private void DetectSwipe()
		{
			if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
			    endTime - startTime <= maximumTime)
			{
				Vector3 direction = endPosition - startPosition;
				Vector2 direction2D = new Vector2(direction.x, direction.y);
				SwipeDirection(direction2D);
			}
		}

		private void SwipeDirection(Vector2 direction)
		{
			var angle = Vector2.Angle(Vector2.up, direction);
			if (direction.x < 0) angle *= -1;

			if (Utils.IsInTheInterval(angle, -30, 30)) OnSwipeUp?.Invoke();
			else if (Utils.IsInTheInterval(angle, 30, 150)) OnSwipeRight?.Invoke();
			else if (Utils.IsInTheInterval(angle, -30, -150)) OnSwipeLeft?.Invoke();
			else OnSwipeDown?.Invoke();
		}
	}
}