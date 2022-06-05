using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] int totalCoins = 3;
    [SerializeField] Sprite usedCoinBox;
    int remainingCoins;

    void Start() {
        remainingCoins = totalCoins;
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            
            Vector2 normal = collision.GetContact(0).normal;
            // If we hit the object from above increment the coins collected
            if (normal.y < 0 && remainingCoins > 0) {
                Coin.coinsCollected++;
                remainingCoins--;
                if (remainingCoins <= 0) {
                    GetComponent<SpriteRenderer>().sprite = usedCoinBox;
                }  
            }

        }
    }
}
