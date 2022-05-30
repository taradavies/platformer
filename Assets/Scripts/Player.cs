using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Animator controller;
    SpriteRenderer renderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // flip only if we're pressing down a key
        if (horizontalInput != 0)
            renderer.flipX = horizontalInput < 0;

        bool isWalking = horizontalInput!=0;
        Animate(isWalking);
    }

    void Animate(bool isWalking) {
        controller.SetBool("isWalking", isWalking);
    }
}
