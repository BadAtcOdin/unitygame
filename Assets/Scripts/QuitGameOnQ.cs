using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameOnQ : MonoBehaviour
{
    void Update()
    {
        // Check if the Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Game Quit!");
            
            // Quit the application
            QuitGame();
        }
    }

    void QuitGame()
    {
        // If we're in the Unity editor, stop play mode
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            
        #else
            // If the game is a build, quit the application
            Application.Quit();
        #endif
    }
}
