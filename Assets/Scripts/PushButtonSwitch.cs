using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite downSprite;
    [SerializeField] UnityEvent onEnter;

    SpriteRenderer spriteRenderer;
    Sprite initialSprite;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = spriteRenderer.sprite;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            spriteRenderer.sprite = downSprite;

            onEnter?.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            spriteRenderer.sprite = initialSprite;
        }
    }
}
