using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            currentState = GameState.Playing;
        else
            currentState = GameState.MainMenu;
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;

        Object.FindFirstObjectByType<UIManager>()?.TogglePausePanel(true);
    }

    public void ResumeGame()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;

        Object.FindFirstObjectByType<UIManager>()?.TogglePausePanel(false);
        Debug.Log("Panel Pause dimatikan, Game Jalan Lagi");
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver) return;

        currentState = GameState.GameOver;
        Time.timeScale = 0f;

        Object.FindFirstObjectByType<UIManager>()?.ToggleGameOverPanel(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}