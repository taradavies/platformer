using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            player.ResetToStart();
        }
    }

    void OnParticleCollision(GameObject other) {
        if (other.TryGetComponent<Player>(out var player)) {
            player.ResetToStart();
        }
    }
}
