using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] float waitTime = 2f;
    Animator controller;

    void Awake() {
        controller = GetComponent<Animator>();
    }
   void OnTriggerEnter2D(Collider2D collider) {
       if (collider.TryGetComponent<Player>(out var player)) {
           controller.SetTrigger("Raise");
           StartCoroutine(LoadNextLevel());
       }
   } 

    IEnumerator LoadNextLevel() {
        // unlock the level
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "unlocked", 1);
        yield return new WaitForSeconds(waitTime);
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       if (sceneIndex >= SceneManager.sceneCountInBuildSettings) {
           SceneManager.LoadScene(0);
       }
       else {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
       }
   }
   
}
