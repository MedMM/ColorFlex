using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEditor;
using Zenject;
using System;
using Game;

namespace Loaders
{
	public class GameLoader : MonoBehaviour
	{
		private GameScenes gameScenes;

		public event Action<float> OnLoadProgressChange;

		[Inject]
		private void Construct(GameScenes gameScenes)
		{
			this.gameScenes = gameScenes;
		}
		//
		// private void Start()
		// {
		// 	StartCoroutine(LoadSceneAsync(scenesManager.GameScene));
		// }

		private IEnumerator LoadSceneAsync(SceneAsset scene)
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync(scene.name);
			OnLoadProgressChange?.Invoke(operation.progress);
			yield return null;
		}
	}
}