using System.Collections.Generic;
using UnityEngine;

namespace UI.Views.InGameUi
{
	public class HealthView : MonoBehaviour
	{
		[SerializeField] private HeartView heartViewPrefab;
		[SerializeField] private List<HeartView> hearts = new List<HeartView>();
		
		public void DisplayHealth(int healthPoints)
		{
			foreach (var her in hearts) her.SetFillAmount(0.1f);

			float step = (float) 1 / heartViewPrefab.ContainsHealth;
			
			if (step * healthPoints > hearts.Count)
			{
				InstantiateHearth();
				DisplayHealth(healthPoints);
				return;
			}

			for (int i = 0; i < healthPoints; i++)
			{
				var heartToInteractIndex = Mathf.FloorToInt(step * i);
				hearts[heartToInteractIndex].AddFillAmount(step);
			}
		}

		private void InitializeHealth(int count)
		{
			for (int i = 0; i < count; i++)
			{
				InstantiateHearth();
			}
		}

		private void InstantiateHearth()
		{
			var healthImage = Instantiate(heartViewPrefab, transform);
			hearts.Add(healthImage);
		}
	}
}