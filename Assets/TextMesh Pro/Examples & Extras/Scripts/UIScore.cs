using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        ScoreSystem.OnScoreChanged += UpdateScoreText;
        UpdateScoreText(ScoreSystem.Score);
    }

    void OnDestroy() {
        ScoreSystem.OnScoreChanged -= UpdateScoreText;
    }

    void UpdateScoreText(int score)
    {
        Debug.Log("Updating score to: " + score);
        scoreText.SetText("SCORE: " + score.ToString());
    }
}
