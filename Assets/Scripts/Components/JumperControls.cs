using UnityEngine;

namespace Components
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class JumperControls : MonoBehaviour
	{
		protected Rigidbody2D rb;
		protected float distanceToRotation = 200;
		protected float distanceX;
		protected float startRotation;
		private Vector2 fingerStartPosition;
		private Vector2 fingerCurrentPosition;
		private float dashForce = -3000;
		private float distanceToDash = 200;
		private float distanceY;
		private bool isActed = true;

		protected void Start()
		{
			rb = gameObject.GetComponent<Rigidbody2D>();

			SwipeLeft();
		}

		protected virtual void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				startRotation = gameObject.transform.rotation.eulerAngles.z;
				fingerStartPosition = Input.mousePosition;
				isActed = false;
			}

			if (Input.GetKey(KeyCode.Mouse0))
			{
				fingerCurrentPosition = Input.mousePosition;
				distanceX = fingerCurrentPosition.x - fingerStartPosition.x;
				distanceY = fingerCurrentPosition.y - fingerStartPosition.y;

				if (!isActed)
				{
					if (distanceX > distanceToRotation)
					{
						SwipeRight();
					}

					if (distanceX < distanceToRotation * -1)
					{
						SwipeLeft();
					}

					if (distanceY < distanceToDash * -1)
					{
						SwipeDown();
					}
				}
			}
		}

		protected void KeyboardControls()
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				SwipeRight();
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				SwipeLeft();
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				Dash();
			}
		}

		protected virtual void Dash()
		{
			if (rb.velocity.y > 0)
			{
				rb.velocity = Vector2.zero;
				rb.AddForce(new Vector2(0, dashForce * 1.34f));
			}
			else
			{
				rb.velocity = Vector2.zero;
				rb.AddForce(new Vector2(0, dashForce * 2f));
			}
		}

		protected virtual void SwipeLeft()
		{
			Debug.Log("SwipedLeft");
			isActed = true;
		}

		protected virtual void SwipeRight()
		{
			Debug.Log("SwipedRight");
			isActed = true;
		}

		protected virtual void SwipeDown()
		{
			Dash();
			isActed = true;
		}
	}
}