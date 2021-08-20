using UnityEditor;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "SO/Create scene holder", fileName = "ScenesHolder")]
	public class GameScenes : ScriptableObject
	{
		[SerializeField] private SceneAsset mainMenuScene;
		[SerializeField] private SceneAsset gameScene;
		[SerializeField] private SceneAsset shopScene;
		
		
		public SceneAsset MainMenuScene => mainMenuScene;
		public SceneAsset GameScene => gameScene;
		public SceneAsset ShopScene => shopScene;
	}
}