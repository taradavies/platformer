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
        Destroy(gameObject);
    }
}
