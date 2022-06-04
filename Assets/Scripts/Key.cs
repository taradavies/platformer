using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] KeyLock keyLock;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            transform.SetParent(player.transform);
            // move it above the players head
            transform.localPosition = Vector3.up;
        }
        else if (collider.TryGetComponent<KeyLock>(out var keyLock)) {
            if (this.keyLock != keyLock) {return;}

            keyLock.Unlock();
            Destroy(gameObject);
        }
    }
}
