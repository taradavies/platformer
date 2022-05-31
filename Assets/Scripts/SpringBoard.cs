using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    [SerializeField] float bounceVelocity = 12.5f;
    [SerializeField] Sprite downSprite;
    SpriteRenderer spriteRenderer;
    Sprite initialSprite;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = spriteRenderer.sprite;
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null) {
                playerRb.velocity = new Vector2(playerRb.velocity.x, bounceVelocity);
                spriteRenderer.sprite = downSprite;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            spriteRenderer.sprite = initialSprite;
        }
    }
}
