using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public string playerName;
    public float score;

    public PlayerScore(string playerName, float score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}

public class PlayerScoreManager : MonoBehaviour
{
    private static List<PlayerScore> scores = new List<PlayerScore>();
    private const string ScoresKey = "PlayerScores";

    // Add a new score
    public static void AddScore(string playerName, float score)
    {
        scores.Add(new PlayerScore(playerName, score));
        SaveScores();
    }

    // Save scores to PlayerPrefs
    private static void SaveScores()
    {
        PlayerPrefs.SetString(ScoresKey, JsonUtility.ToJson(new SerializableScores(scores)));
        PlayerPrefs.Save();
    }

    // Load scores from PlayerPrefs
    public static List<PlayerScore> LoadScores()
    {
        if (scores.Count == 0)
        {
            string json = PlayerPrefs.GetString(ScoresKey, string.Empty);
            if (!string.IsNullOrEmpty(json))
            {
                SerializableScores loadedScores = JsonUtility.FromJson<SerializableScores>(json);
                scores = new List<PlayerScore>(loadedScores.scores);
            }
        }
        return scores;
    }
}

// Wrapper for JSON serialization
[System.Serializable]
public class SerializableScores
{
    public List<PlayerScore> scores;

    public SerializableScores(List<PlayerScore> scores)
    {
        this.scores = scores;
    }
}
