using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private Camera mainCamera;
    private CameraBackgroundColor cameraBackgroundColor;
    private int score = 0;
    private int bestScore = 0;
    [SerializeField] private Color[] colors = new Color[4];
    [SerializeField] private Color defaultColor;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [Header("BG settings")]
    [SerializeField] private GameObject background;
    [SerializeField] [Range(0f, 5f)] private float BGStep; 
    [SerializeField] [Range(0.01f, 2f)] private float BGStepTime; 

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
        //_playerSpawner = GetComponent<PlayerSpawner>();

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

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SetCameraBackgroundTime(float duration)
    {
        cameraBackgroundColor.SetDuration(duration);
    }

    public void BackgroundStep()
    {
        StartCoroutine(IEnumerators.SmoothLerp(background, background.transform.position + new Vector3(0, BGStep * -1 , 0), BGStepTime));

        //background.transform.position += new Vector3(0, BGStep, 0);
    }

    public void GameOver()
    {
        UI_script.instance.GameOver();
    }

    public void PlayAgain()
    {
        _playerSpawner.SpawnPlayer();
        UI_script.instance.PlayAgain();
        score = 0;
        UI_script.instance.SetCurrentScoreText(score);
        //SmoothResetScore();
    }
}