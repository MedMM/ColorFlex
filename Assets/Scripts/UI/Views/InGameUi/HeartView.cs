using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.InGameUi
{
	public class HeartView : MonoBehaviour
	{
		[SerializeField] private Image image;
		[SerializeField] private int containsHealth; //Max Health 

		public int ContainsHealth => Mathf.Clamp(containsHealth, 1, int.MaxValue);

		public void SetCurrentHealth(int health)
		{
			image.fillAmount = (float) health / containsHealth;
		}
		
		public void SetFillAmount(float fillAmount) => image.fillAmount = fillAmount;
		public void AddFillAmount(float fillAmount) => image.fillAmount += fillAmount;
	}
}