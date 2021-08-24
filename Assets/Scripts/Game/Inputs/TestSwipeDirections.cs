using UniRx;
using UnityEngine;

namespace Game.Inputs
{
	public class TestSwipeDirections : MonoBehaviour
	{
		[SerializeField] private InputManager input;

		private void Start()
		{
			input.Swipes.OnSwipeDown += () => Debug.Log("Down");
			input.Swipes.OnSwipeLeft += () => Debug.Log("L");
			input.Swipes.OnSwipeRight += () => Debug.Log("R");
			input.Swipes.OnSwipeUp += () => Debug.Log("Up");

			input.Drag.OnDrag += (Vector2 v2) => Debug.Log($"Vect: {v2}");
		}
	}
}