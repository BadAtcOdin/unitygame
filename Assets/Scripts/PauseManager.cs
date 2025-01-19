using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);

        // Block shooting while paused
        FindObjectOfType<DartShooter>().BlockShooting();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);

        // Allow shooting after resuming
        FindObjectOfType<DartShooter>().AllowShooting();
    }

    public void ReturnToMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
