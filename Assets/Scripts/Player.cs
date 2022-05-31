using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ground check fields
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius = 0.2f;
    [SerializeField] LayerMask mask;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] int extraJumps;
    int jumpsRemaining;
    Rigidbody2D rb;
    Animator controller;
    SpriteRenderer spriteRenderer;
    Vector2 startingPos;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        startingPos = transform.position;
        jumpsRemaining = extraJumps;
    }

    void Update()
    {
        // read player input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // set the isGrounded variable
        isGrounded = IsGrounded();

        // reset the max jumps
        if (isGrounded) {
            jumpsRemaining = extraJumps;
        }

        // enables friction
        if (Mathf.Abs(horizontalInput) >= 1)
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // flip only if we're pressing down a key
        if (horizontalInput != 0)
            spriteRenderer.flipX = horizontalInput < 0;

        // animate movement
        bool isWalking = horizontalInput!=0;
        Animate(isWalking);

        // checks for jumps
        if (Input.GetButtonDown("Jump") && isGrounded) {
            ExecuteJump();
        }
        // double jumps
        else if (Input.GetButtonDown("Jump") && jumpsRemaining > 0) {
            ExecuteJump();
        }

    }

    bool IsGrounded()
    {
       var hit = Physics2D.OverlapCircle(groundCheck.position, radius, mask);
       return hit;
    }

    public void ResetToStart()
    {
        transform.position = startingPos;
    }

    private void ExecuteJump()
    {
        jumpsRemaining--;
        rb.AddForce(Vector2.up * jumpForce); 
    }

    void Animate(bool isWalking) {
        controller.SetBool("isWalking", isWalking);
    }
    
}
