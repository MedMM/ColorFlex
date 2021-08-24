using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
	public static Vector3 ScreenToWorldPoint(Camera camera, Vector3 position)
	{
		position.z = camera.nearClipPlane;
		return camera.ScreenToWorldPoint(position);
	}

	public static bool IsInTheInterval(float value, float minPosition, float maxPosition)
	{
		var min = Math.Min(minPosition, maxPosition);
		var max = Math.Max(minPosition, maxPosition);
		return value >= min && value <= max;
	}
}