using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Inputs
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField] private float minimumSwipeDistance = 0.2f;
		[SerializeField] private float maximumSwipeTime = 1f;
		private SwipeDetection swipeDetection;
		private DragDetection dragDetection;
		private TouchControls touchControls;
		private Camera mainCamera;

		#region Events

		public delegate void StartTouch(Vector2 position, float time);

		public event StartTouch OnStartTouch;

		public delegate void EndTouch(Vector2 position, float time);

		public event EndTouch OnEndTouch;

		#endregion

		public SwipeDetection Swipes => swipeDetection;
		public DragDetection Drag => dragDetection;

		private void Awake()
		{
			swipeDetection = new SwipeDetection(this, ref minimumSwipeDistance, ref maximumSwipeTime);
			dragDetection = new DragDetection(this);
			touchControls = new TouchControls();
			mainCamera = Camera.main;
		}

		private void OnEnable()
		{
			touchControls.Enable();
		}

		private void OnDisable() => touchControls.Disable();

		private void Start()
		{
			touchControls.Swipe.PrimaryContact.started += StartTouchPrimary;
			touchControls.Swipe.PrimaryContact.canceled += EndTouchPrimary;
		}

		private void StartTouchPrimary(InputAction.CallbackContext context) =>
			OnStartTouch?.Invoke(Utils.ScreenToWorldPoint(mainCamera,
				touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float) context.startTime);

		private void EndTouchPrimary(InputAction.CallbackContext context) =>
			OnEndTouch?.Invoke(Utils.ScreenToWorldPoint(mainCamera,
				touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>()), (float) context.time);

		public Vector2 PrimaryPosition()
			=> Utils.ScreenToWorldPoint(mainCamera, touchControls.Swipe.PrimaryPosition.ReadValue<Vector2>());
	}
}