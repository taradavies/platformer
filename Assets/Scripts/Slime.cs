using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Transform frontSensor;
    [SerializeField] Transform backSensor;
    [SerializeField] LayerMask mask;
    [SerializeField] float distanceFromGround;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = -1;
    }

    void Update()
    {
        rb.velocity = new Vector2(direction, rb.velocity.y);
        
        if (direction < 0)
        {
            ScanSensor(frontSensor);
        }
        else {
            ScanSensor(backSensor);
        }
    }

    void ScanSensor(Transform sensor)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            sensor.position,
            Vector2.down,
            distanceFromGround,
            mask);

            if (!hit) {
                TurnAround();
            }
    }

    void TurnAround() {
        direction *= -1;
        spriteRenderer.flipX = direction > 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            player.ResetToStart();
        }
    }
}
