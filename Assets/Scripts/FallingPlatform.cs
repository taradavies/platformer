using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isPlayerOnPlatform; 
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            isPlayerOnPlatform = true;
            Wiggle();
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            isPlayerOnPlatform = false;
        }
    }

    private void Wiggle()
    {
        // wiggle
    }
}
