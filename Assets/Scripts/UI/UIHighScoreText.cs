using TMPro;
using UnityEngine;

public class UIHighScoreText : MonoBehaviour
{
    TMP_Text highScoreText;

    void Start() {
        highScoreText = GetComponent<TMP_Text>(); 
        highScoreText.SetText($"HIGHSCORE: {PlayerPrefs.GetInt("highscore")}");
    }
}
