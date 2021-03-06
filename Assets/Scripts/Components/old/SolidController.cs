using Misc;

namespace Components
{
    public class SolidController : JumperControls
    {
        private float rotationTime = 0.2f;
        private float playerZRotation = 90;

        protected override void Update()
        {
            base.Update();
            KeyboardControls();
        }
    
        protected override void SwipeLeft()
        {
            base.SwipeLeft();
            playerZRotation -= 90;
            StartCoroutine(Enumerators.SmoothRotation(gameObject, playerZRotation, rotationTime));
        }

        protected override void SwipeRight()
        {
            base.SwipeRight();
            playerZRotation += 90;
            StartCoroutine(Enumerators.SmoothRotation(gameObject, playerZRotation, rotationTime));
        }
    }
}
