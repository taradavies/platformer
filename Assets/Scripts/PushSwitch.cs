using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushSwitch : MonoBehaviour
{
    [SerializeField] SwitchPosition startingPosition;
    [SerializeField] Sprite leftSwitch;
    [SerializeField] Sprite rightSwitch;
    [SerializeField] Sprite centerSwitch;

    [SerializeField] UnityEvent onRightToggle;
    [SerializeField] UnityEvent onLeftToggle; 
    [SerializeField] UnityEvent onCenterToggle;
    SpriteRenderer spriteRenderer;

    enum SwitchPosition
    {
        LEFT,
        RIGHT,
        CENTER,
    }

    SwitchPosition currentPosition;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetTogglePosition(startingPosition, true);
    }

    // called once per frame for every collider inside the trigger
    void OnTriggerStay2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {

            var playerRb =  player.GetComponent<Rigidbody2D>();
            if (playerRb == null) 
                return;
            
            // during the frame of the collision check if the player's position is now greater
            bool switchWasOnRight = player.transform.position.x > transform.position.x;
            float playerVelocity = playerRb.velocity.x;

            if (switchWasOnRight && playerVelocity > 0) 
                SetTogglePosition(SwitchPosition.RIGHT);
            else if (!switchWasOnRight && playerVelocity < 0)
                SetTogglePosition(SwitchPosition.LEFT);
            
        }
    }

    void SetTogglePosition(SwitchPosition position, bool force = false) {
        if (!force && currentPosition == position) {return;}
        currentPosition = position;

        switch (position) {
            case SwitchPosition.RIGHT:
                spriteRenderer.sprite = rightSwitch;
                onRightToggle.Invoke();  
                break;
            case SwitchPosition.LEFT:
                spriteRenderer.sprite = leftSwitch;
                onLeftToggle.Invoke();
                break;
            case SwitchPosition.CENTER:
                spriteRenderer.sprite = centerSwitch;
                onCenterToggle.Invoke();
                break;
        }

    }
    void OnValidate() {
        SpriteRenderer tempRenderer = GetComponent<SpriteRenderer>();
        switch (startingPosition) {
            case SwitchPosition.RIGHT:
                tempRenderer.sprite = rightSwitch;
                onRightToggle.Invoke();  
                break;
            case SwitchPosition.LEFT:
                tempRenderer.sprite = leftSwitch;
                onLeftToggle.Invoke();
                break;
            case SwitchPosition.CENTER:
                tempRenderer.sprite = centerSwitch;
                onCenterToggle.Invoke();
                break;
        }
    }
    
}
