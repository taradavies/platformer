using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushSwitch : MonoBehaviour
{
    [SerializeField] Sprite leftSwitch;
    [SerializeField] Sprite rightSwitch;

    [SerializeField] UnityEvent onRightToggle;
    [SerializeField] UnityEvent onLeftToggle; 
    SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            
            bool wasComingFromRight = player.transform.position.x > transform.position.x;

            if (wasComingFromRight) 
                FlipLeft();
            else 
                FlipRight();
        }
    }
    void FlipRight()
    {
        spriteRenderer.sprite = rightSwitch;
        onRightToggle.Invoke();
    }

    void FlipLeft()
    {
        spriteRenderer.sprite = leftSwitch;
        onLeftToggle.Invoke();
    }
}
