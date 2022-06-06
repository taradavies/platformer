using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite pressedSprite;
    [SerializeField] UnityEvent onPressed;
    [SerializeField] UnityEvent onReleased;

    [SerializeField] int playerNumber = 1;

    SpriteRenderer spriteRenderer;
    Sprite releasedSprite;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        releasedSprite = spriteRenderer.sprite;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>();
        if (player == null || player.PlayerNumber != playerNumber) {
            return;
        }
        BecomePressed();
    }

    private void BecomePressed()
    {
        spriteRenderer.sprite = pressedSprite;
        onPressed?.Invoke();
    }

    void OnTriggerExit2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>();
        if (player == null || player.PlayerNumber != playerNumber || OnReleaseIsEmpty()) {
            return;
        }
        BecomeReleased();
    }

    bool OnReleaseIsEmpty()
    {
        return onReleased.GetPersistentEventCount() == 0;
    }

    private void BecomeReleased()
    {
            spriteRenderer.sprite = releasedSprite;
            onReleased.Invoke();
    }
}