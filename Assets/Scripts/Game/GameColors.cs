using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "Game Colors", menuName = "SO/Create Color Palette")]
	public class GameColors : ScriptableObject
	{
		[SerializeField] private Color transitionFillColor;
		[SerializeField] private Color[] playerColors;

		public Color TransitionFillColor => transitionFillColor;
	}
}
