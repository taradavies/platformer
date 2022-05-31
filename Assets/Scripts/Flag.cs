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
           Invoke("LoadNextLevel", waitTime);
       }
   } 

   void LoadNextLevel() {
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       if (sceneIndex >= SceneManager.sceneCount) {
           SceneManager.LoadScene(0);
           return;
       }
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
