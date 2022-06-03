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
    [SerializeField] Canvas canvas;

    bool isOpen = false;

    [ContextMenu("Open Door")]
    void Open() {
        isOpen = true;
        doorTopRenderer.sprite = doorTop;
        doorMidRenderer.sprite = doorMid;
        if (canvas!=null) {canvas.enabled = false;}
    }

    void Update() {
        if (!isOpen && Coin.coinsCollected >= requiredCoins && exitDoor!=null) {
            Open();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!isOpen) {return;}

        if (collider.TryGetComponent<Player>(out var player) && exitDoor!=null) {
            player.TeleportTo(exitDoor.transform.position);
        }
    }
    
}
