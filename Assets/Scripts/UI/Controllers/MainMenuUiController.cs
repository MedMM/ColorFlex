using DG.Tweening;
using Game;
using UI.Views;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.Controllers
{
	public class MainMenuUiController : MonoBehaviour
	{
		[SerializeField, HideInInspector] private MainMenuUiView mainMenuUiView;
		private GameScenes gameScenes;
		private GameColors gameColors;

		[Inject]
		private void Construct(
			GameScenes gameScenes,
			GameColors gameColors)
		{
			this.gameScenes = gameScenes;
			this.gameColors = gameColors;
			
		}

		private void Start()
		{
			mainMenuUiView.playButton.button.OnClickAsObservable().Subscribe(s => OnPlayButtonClick());
			mainMenuUiView.shopButton.button.OnClickAsObservable().Subscribe(s => OnShopButtonClick());
			mainMenuUiView.settingsButton.button.OnClickAsObservable().Subscribe(s => OnSettingsButtonClick());
		}

		private void OnPlayButtonClick()
		{
			ButtonNextSceneTransition(mainMenuUiView.playButton, 1f)
				.onComplete += () => { SceneManager.LoadScene(gameScenes.GameScene.name); };
		}

		private void OnShopButtonClick()
		{
			ButtonNextSceneTransition(mainMenuUiView.shopButton, 1f)
				.onComplete += () => { SceneManager.LoadScene(gameScenes.ShopScene.name); };
		}

		private void OnSettingsButtonClick()
		{
		}

		private Sequence ButtonNextSceneTransition(MainMenuButton button, float time)
		{
			Vector3 center = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
			button.transform.SetAsLastSibling();

			var sequence = DOTween.Sequence();
			sequence.Append(button.transform.DORotate(new Vector3(0, 0, 180), time * 0.8f));
			sequence.Join(button.iconImage.DOColor(Color.clear, time * 0.8f));
			sequence.Append(button.transform.DOScale(8f, time));
			sequence.Join(button.transform.DOLocalRotate(new Vector3(0, 0, 30f), time));
			sequence.Join(button.transform.DOMove(center, time));
			sequence.Join(button.backgroundImage.DOColor(gameColors.TransitionFillColor, time));

			return sequence;
		}

		private void OnValidate()
		{
			if (mainMenuUiView == null)
				mainMenuUiView = GetComponent<MainMenuUiView>();
		}
	}
}