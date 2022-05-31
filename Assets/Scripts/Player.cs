using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 200f;
    Rigidbody2D rb;
    Animator controller;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // enables friction

        if (Mathf.Abs(horizontalInput) >= 1)
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // flip only if we're pressing down a key
        if (horizontalInput != 0)
            spriteRenderer.flipX = horizontalInput < 0;

        bool isWalking = horizontalInput!=0;
        Animate(isWalking);

        if (Input.GetButtonDown("Jump")) {
            ExecuteJump();
        }
    }

    private void ExecuteJump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    void Animate(bool isWalking) {
        controller.SetBool("isWalking", isWalking);
    }
}
