using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.InGameUi
{
	public class InGameUiView : MonoBehaviour
	{
		[SerializeField] private HealthView healthView;
		[SerializeField] private GameScoreView gameScoreView;
		[SerializeField] private Button pauseGameButton;
	}
}