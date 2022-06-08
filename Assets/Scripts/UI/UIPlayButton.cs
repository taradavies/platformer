
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPlayButton : MonoBehaviour
{
    [SerializeField] GameObject content;
    UIStartLevelButton[] levelButtons;

    void Awake() {
        levelButtons = content.GetComponentsInChildren<UIStartLevelButton>();
    }

    public void OnClicked() {
        string currentLevelUnlocked = GetLevelUnlocked();

        SceneManager.LoadScene(currentLevelUnlocked);
    }

    string GetLevelUnlocked()
    {
        foreach (var levelButton in levelButtons) {
            var buttonScript = levelButton.GetComponent<UIStartLevelButton>();
            string key = buttonScript.level + "unlocked";
            Debug.Log("key: " + key);
            Debug.Log("Playerprefs int: " + PlayerPrefs.GetInt(key));
            if (PlayerPrefs.GetInt(key) == 0) {
                return buttonScript.level;
            }
        }
        return "Level1";
    }
}
