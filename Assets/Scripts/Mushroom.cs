using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] float bounceVelocity = 10f;
    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null) {
                audioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, bounceVelocity);
            }
        }
    }
}
