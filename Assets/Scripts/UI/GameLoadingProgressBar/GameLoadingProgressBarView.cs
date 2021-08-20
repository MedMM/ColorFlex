using Loaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameLoadingProgressBar
{
	public class GameLoadingProgressBarView : MonoBehaviour
	{
		[SerializeField] private Slider slider;
		private GameLoader gameLoader;

		[Inject]
		private void Construct(GameLoader gameLoader)
		{
			this.gameLoader = gameLoader;
		}
		private void OnEnable()
		{
			gameLoader.OnLoadProgressChange += ChangeSliderValue;
		}

		private void OnDisable()
		{
			gameLoader.OnLoadProgressChange -= ChangeSliderValue;
		}

		void ChangeSliderValue(float value)
		{
			slider.value = value;
		}
	}
}