using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.left;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            player.ResetToStart();
        }
    }
}
