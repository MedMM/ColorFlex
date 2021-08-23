using UnityEngine;

namespace Components
{
    public class SmoothController : JumperControls
    {
        private float rotationMultipler = 0.25f;

        private void Start()
        {
            distanceToRotation = 0;
        }

        protected override void SwipeLeft()
        {
            var rotation = startRotation + (distanceX * rotationMultipler);

            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                rotation);
        }

        protected override void SwipeRight()
        {
            SwipeLeft();
        }
    }
}
