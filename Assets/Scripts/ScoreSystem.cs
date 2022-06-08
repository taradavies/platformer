using UnityEngine;

public static class ScoreSystem
{
    // uint allows large numbers but no negatives
    // long is a HUGE integer
    static int score;
    public static void AddScore(int points) {
        score += points;
        Debug.Log($"Score: {score}");
    }
}
