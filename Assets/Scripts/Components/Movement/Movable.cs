using DG.Tweening;
using UnityEngine;

namespace Components.Movement
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Movable : MonoBehaviour
	{
		[SerializeField, HideInInspector] private Rigidbody2D rb;
		[SerializeField] private float rotationTime;
		[SerializeField] private float dashTime;
		[SerializeField] private Ease dashDownEase;
		[SerializeField] private Ease dashBackEase;
		[SerializeField] private float rotationMultiplayer = 1f;
		private Vector2 mainPosition = Vector2.zero;
		private float playerRotation;

		private Vector2 MainPosition
		{
			get => mainPosition;
			set => mainPosition = value;
		}

		public float Rotation
		{
			get => rb.rotation;
			set => rb.rotation = value;
		}

		public void Rotate(float angle)
		{
			playerRotation += angle;
			rb.DORotate(playerRotation, rotationTime);
		}

		public void Dash(Vector2 position, float time)
		{
			Sequence dashSequence = DOTween.Sequence();
			dashSequence.Append(rb.DOMove(position, time / 2).SetEase(dashDownEase));
			dashSequence.Append(rb.DOMove(mainPosition, time / 2).SetEase(dashBackEase));
		}

		private void OnValidate()
		{
			if (rb == null)
				rb = GetComponent<Rigidbody2D>();
		}
	}
}