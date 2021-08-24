using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Inputs
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField] private float minimumSwipeDistance = 0.2f;
		[SerializeField] private float maximumSwipeTime = 1f;
		private TouchControls touchControls;
		private SwipeDetection swipeDetection;
		private Camera mainCamera;

		public SwipeDetection Swipes => swipeDetection;

		#region Events

		public delegate void StartTouch(Vector2 position, float time);

		public event StartTouch OnStartTouch;

		public delegate void EndTouch(Vector2 position, float time);

		public event EndTouch OnEndTouch;

		#endregion

		private void Awake()
		{
			swipeDetection = new SwipeDetection(this, ref minimumSwipeDistance, ref maximumSwipeTime);
			touchControls = new TouchControls();
			mainCamera = Camera.main;
		}

		private void OnEnable() => touchControls.Enable();

		private void OnDisable() => touchControls.Disable();

		private void Start()
		{
			touchControls.Touch.TouchPress.started += ctx => Log("Touch.TouchPress.started");
			touchControls.Swipe.PrimaryContact.started += StartTouchPrimary;
			touchControls.Swipe.PrimaryContact.canceled += EndTouchPrimary;
			touchControls.Touch.TouchDrag.performed += ctx => OnTouchDrag(ctx, "performed");
			touchControls.Touch.TouchDrag.started += ctx => OnTouchDrag(ctx, "started");
			touchControls.Touch.TouchDrag.canceled += ctx => OnTouchDrag(ctx, "canceled");
		}

		private void OnTouchDrag(InputAction.CallbackContext context, string str)
		{
			Debug.Log("OnTouchDrag " + str);
		}

		private void StartTouchPrimary(InputAction.CallbackContext context)
		{
			OnStartTouch?.Invoke(Utils.ScreenToWorldPoint(mainCamera,
				touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float) context.startTime);
		}

		private void EndTouchPrimary(InputAction.CallbackContext context)
		{
			OnEndTouch?.Invoke(Utils.ScreenToWorldPoint(mainCamera,
				touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float) context.time);
		}

		public Vector2 PrimaryPosition()
		{
			return Utils.ScreenToWorldPoint(mainCamera, touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>());
		}

		private void Log(string msg)
		{
			Debug.Log(msg);
		}
	}
}