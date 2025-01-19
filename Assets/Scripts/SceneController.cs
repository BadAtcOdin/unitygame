using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with the exact name of your game scene
    }

    public void QuitGame()
    {
    Application.Quit(); // Closes the application
    Debug.Log("Game Quit!"); // For testing in the editor
    }   

}
