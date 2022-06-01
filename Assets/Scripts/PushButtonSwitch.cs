using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite pressedSprite;
    [SerializeField] UnityEvent onPressed;
    [SerializeField] UnityEvent onReleased;

    SpriteRenderer spriteRenderer;
    Sprite releasedSprite;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        BecomeReleased();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player))
            BecomePressed();
    }

    private void BecomePressed()
    {
        spriteRenderer.sprite = pressedSprite;
        onPressed?.Invoke();
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player))
        {
            BecomeReleased();
        }
    }
    private void BecomeReleased()
    {
        spriteRenderer.sprite = releasedSprite;
        onReleased?.Invoke();
    }
}