using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private float score = 0f; // Score of the player
    [SerializeField] TextMeshProUGUI scoreText; // Reference to the Score TextMesh component
    
    void Start()
    {
        UpdateScore(0); 
    }

    public void UpdateScore(float value)
    {
        score += value;
        Debug.Log("Score: " + score);

        scoreText.text = "Score: " + score.ToString();
    }

    public float GetScore()
    {
        return score;
    }
}
