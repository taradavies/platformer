using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    // uint allows large numbers but no negatives
    // long is a HUGE integer
    static int score;
    static int highScore;

    void Start() {
        highScore = PlayerPrefs.GetInt("highscore");
    }
    public static void AddScore(int points) {
        score += points;
        OnScoreChanged?.Invoke(score);

        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            Debug.Log("New highscore: " + highScore);
        }
    }
}