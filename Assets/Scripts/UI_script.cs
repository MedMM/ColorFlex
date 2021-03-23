using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_script : MonoBehaviour
{
    public static UI_script instance;

    Animator _animator;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Text currentScoreText; 
    [SerializeField] private Text bestScoreText;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Initialize();

    }

    private void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetCurrentScoreText(int value)
    {
        currentScoreText.text = value.ToString();
    }

    public void SetBestScoreText(int value)
    {
        bestScoreText.text = $"Best score: {value}";
    }

    public void RemoveHeart(int index)
    {
        hearts[index].gameObject.SetActive(false);
    }

    public void RestoreHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        GameManager.instance.SetCameraBackgroundTime(.5f);
        _animator.SetBool("isGameOver", true);
    }

    public void PlayAgain()
    {
        RestoreHearts();
        GameManager.instance.SetCameraBackgroundTime(3f);
        _animator.SetBool("isGameOver", false);
    }
}
