using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Tweens : MonoBehaviour
{
    [SerializeField] float appearingTime = 1;
    string sceneToLoad;


    [SerializeField] private float buttonClickTime = 1;
    [SerializeField] private float fadeTime = 1;
    Vector3 fullScreenScale = new Vector3(5, 5, 1);
    float fullScreenRotation = 90;


    private void Start()
    {
        var tempColor = gameObject.GetComponent<Image>().color;
        tempColor.a = 1f;
        gameObject.GetComponent<Image>().color = tempColor;
        SmoothAppear();
    }

    void SmoothAppear()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0, appearingTime);
    }
    void SmoothDisappear()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1, appearingTime);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FillScreenAndLoadScene(GameObject gameObject)
    { 
        LeanTween.scale(gameObject, fullScreenScale, buttonClickTime).setOnComplete(LoadScene);
        LeanTween.move(gameObject, new Vector2(0, 0), buttonClickTime);
        LeanTween.rotateZ(gameObject, fullScreenRotation, buttonClickTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SetSceneToLoad(sceneName);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1, appearingTime).setOnComplete(LoadScene);
    }

    public void SetSceneToLoad(string sceneName)
    {
        sceneToLoad = sceneName;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
