using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Transform frontSensor;
    [SerializeField] Transform backSensor;
    [SerializeField] LayerMask mask;
    [SerializeField] float distanceFromGround;
    [SerializeField] Sprite deathSprite;
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

            Vector2 normal = collision.GetContact(0).normal;

            if (normal.y < -0.5) {
                StartCoroutine(Die());
            }
            else {
                player.ResetToStart();
            }
        }
    }

    IEnumerator Die() {
        spriteRenderer.sprite = deathSprite;
        GetComponent<Animator>().enabled = false;    
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        rb.simulated = false;

        GetComponent<AudioSource>().Play();

        // fade
        float alpha = 1;
        while (alpha > 0) {
            // wait until the next frame
            yield return null;
            alpha -= Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }

        gameObject.SetActive(false);
    }
}

