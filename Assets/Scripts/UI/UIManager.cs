using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    void Start()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void TogglePausePanel(bool isActive)
    {
        if (pausePanel != null) pausePanel.SetActive(isActive);

        if (isActive && gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void ToggleGameOverPanel(bool isActive)
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(isActive);

        if (isActive && pausePanel != null) pausePanel.SetActive(false);
    }

    public void ClickPause()
    {
        if (GameManager.Instance != null) GameManager.Instance.PauseGame();
    }

    public void ClickResume()
    {
        if (GameManager.Instance != null) GameManager.Instance.ResumeGame();
    }

    public void ClickRestart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickStartGame()
    {
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }
}