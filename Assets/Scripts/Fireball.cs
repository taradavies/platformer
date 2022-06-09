using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float Direction { get; set; }

    void Update()
    {
        rb.velocity = Vector2.right * moveSpeed * Direction;
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.TryGetComponent<ITakeHit>(out var entity)) {
            entity.TakeDamage();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<ITakeHit>(out var entity)) {
            entity.TakeDamage();
        }
        Destroy(gameObject);
    }
}
