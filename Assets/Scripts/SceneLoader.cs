using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void _LoadScene(Object scene)
    {
        SceneManager.LoadScene(scene.name);
        Debug.Log("Play button clicked");
    }

    public void _GameScene() => SceneManager.LoadScene("GameScene");
    public void _ShopScene() => SceneManager.LoadScene("ShopScene");
    public void _MenuScene() => SceneManager.LoadScene("MenuScene");

    public void _QuitGame() => Application.Quit();
    
}

