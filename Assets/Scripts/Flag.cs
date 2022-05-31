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
        yield return new WaitForSeconds(waitTime);
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       if (sceneIndex >= SceneManager.sceneCount) {
           SceneManager.LoadScene(0);
       }
       else {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
       }
   }
   
}
