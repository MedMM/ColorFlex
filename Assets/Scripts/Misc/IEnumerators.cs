using System.Collections;
using UnityEngine;

namespace Misc
{
    public class Enumerators : MonoBehaviour
    {
        public static IEnumerator SmoothLerp(GameObject gameObject, Vector3 finalPosition, float time)
        {
            Vector3 startingPos = gameObject.transform.localPosition;
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                if (gameObject == null) { yield break; }
                gameObject.transform.localPosition = Vector3.Lerp(startingPos, finalPosition, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            if (gameObject == null) { yield break; }
            gameObject.transform.localPosition = finalPosition;
        }

        public static IEnumerator SmoothRotation(GameObject gameObject, float angle, float duration)
        {
            Quaternion from = gameObject.transform.rotation;
            Quaternion to = Quaternion.Euler(Vector3.forward * angle);

            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                gameObject.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            gameObject.transform.rotation = to;
        }

        public static IEnumerator SmoothRotation(GameObject gameObject, Vector3 axis, float angle, float duration)
        {
            Quaternion from = gameObject.transform.rotation;
            Quaternion to = gameObject.transform.rotation;
            to *= Quaternion.Euler(axis * angle);

            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                gameObject.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            gameObject.transform.rotation = to;
        }

        public static IEnumerator SmoothLerpAndDestroy(GameObject gameObject, Vector3 finalPosition, float time)
        {
            Vector3 startingPos = gameObject.transform.localPosition;
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                if (gameObject == null) { yield break; }

                gameObject.transform.localPosition = Vector3.Lerp(startingPos, finalPosition, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            if (gameObject == null) { yield break; }
            gameObject.transform.localPosition = finalPosition;
            Destroy(gameObject);
        }

        public static IEnumerator ColorLerp(SpriteRenderer spriteRenderer, Color startColor, Color endColor, float time)
        {
            for (float t = 0.1f; t < time; t += 0.1f)
            {
                spriteRenderer.color = Color.Lerp(startColor, endColor, t / time);
                yield return null;
            }
            spriteRenderer.color = endColor;
        }
    }
}
