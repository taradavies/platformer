using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] ParticleSystem breakFX;
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Vector2 normal = collision.GetContact(0).normal;
            // hit from the bottom
            if (normal.y > 0) {
                TakeHit();
            }
        }
    }

    void TakeHit()
    {
        breakFX.Play();
        
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
