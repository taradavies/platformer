using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    // uint allows large numbers but no negatives
    // long is a HUGE integer
    public static int Score { get; private set; }

    static int highScore;

    void Awake() {
        highScore = PlayerPrefs.GetInt("highscore");
        Score = 0;
    }
    public static void AddScore(int points) {
        Score += points;
        OnScoreChanged?.Invoke(Score);

        if (Score > highScore) {
            highScore = Score;
            PlayerPrefs.SetInt("highscore", highScore);
            Debug.Log("New highscore: " + highScore);
        }
    }
}