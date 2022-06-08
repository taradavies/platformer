using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartLevelButton : MonoBehaviour
{
    [SerializeField] string levelName;

    public string level => levelName;
    public void LoadLevel() {
        SceneManager.LoadScene(levelName);
    }
}
