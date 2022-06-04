using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    static int keysCollected = 0;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            transform.SetParent(player.transform);
            // move it above the players head
            transform.localPosition = Vector3.up;
        }
    }
}
