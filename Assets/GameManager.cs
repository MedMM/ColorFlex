using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Color[] colors = new Color[4];
    [SerializeField] private Color defaultColor;
    private Camera mainCamera;
    private CameraBackgroundColor cameraBackgroundColor;
    private int score;
    private int bestScore;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        mainCamera = Camera.main;
        cameraBackgroundColor = mainCamera.gameObject.GetComponent<CameraBackgroundColor>();

        score = 0;
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    public void AddScore(int add)
    {
        score += add;
        UI_script.instance.SetCurrentScoreText(score);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }

    public Color GetColor(int index)
    {
        return index <= colors.Length - 1 ? colors[index] : defaultColor;
    }

    public void SetDefaultColor(Color color)
    {
        defaultColor = color;
    }

    public void SetCameraBackgroundTime(float duration)
    {
        cameraBackgroundColor.SetDuration(duration);
    }

    public void GameOver()
    {
        UI_script.instance.GameOver();
    }

    public void PlayAgain()
    {
        UI_script.instance.PlayAgain();
        score = 0;
        UI_script.instance.SetCurrentScoreText(score);
    }
}