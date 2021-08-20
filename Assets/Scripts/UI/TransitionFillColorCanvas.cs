using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public class TransitionFillColorCanvas : MonoBehaviour
	{
		[SerializeField] private Image fillImage;
		[SerializeField] private float fadeOutTime;
		[Inject] public GameColors gameColors;
		
		private void Start()
		{
			fillImage.color = gameColors.TransitionFillColor;
			fillImage.DOColor(Color.clear, fadeOutTime);
		}
	}
}