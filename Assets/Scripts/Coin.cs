using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    static int coinsCollected;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            gameObject.SetActive(false);
            coinsCollected++;
            Debug.Log($"Coins Collected {coinsCollected}");
        }
    }
}
