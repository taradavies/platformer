using UnityEngine;

public class UILockable : MonoBehaviour {

    // checking if a level has been unlocked
    void OnEnable() {
        var startButton = GetComponent<UIStartLevelButton>();
        string key = startButton.level + "unlocked"; 
        int unlocked = PlayerPrefs.GetInt(key);
        if (unlocked == 0) 
            gameObject.SetActive(false);
        
    }
}
