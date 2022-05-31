using UnityEngine;

public class Flag : MonoBehaviour
{
    Animator controller;

    void Awake() {
        controller = GetComponent<Animator>();
    }
   void OnTriggerEnter2D(Collider2D collider) {
       if (collider.TryGetComponent<Player>(out var player)) {
           controller.SetTrigger("Raise");
       }
   } 
}
