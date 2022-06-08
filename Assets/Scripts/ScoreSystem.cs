using System;
using UnityEngine;

public static class ScoreSystem
{
    public static event Action<int> OnScoreChanged;

    // uint allows large numbers but no negatives
    // long is a HUGE integer
    static int score;
    public static void AddScore(int points) {
        score += points;
        OnScoreChanged?.Invoke(score);
    }
}
