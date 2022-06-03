using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite doorTop;
    [SerializeField] Sprite doorMid;
    [SerializeField] SpriteRenderer doorTopRenderer;
    [SerializeField] SpriteRenderer doorMidRenderer;
    [SerializeField] int requiredCoins = 3;

    [SerializeField] Door exitDoor;

    [ContextMenu("Open Door")]
    void Open() {
        doorTopRenderer.sprite = doorTop;
        doorMidRenderer.sprite = doorMid;
    }

    void Update() {
        if (Coin.coinsCollected >= requiredCoins && exitDoor!=null) {
            Open();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player) && exitDoor!=null) {
            player.TeleportTo(exitDoor.transform.position);
        }
    }
    
}
