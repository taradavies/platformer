using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Number")]
    [SerializeField] [Range(1,2)] int playerNumber = 1;
    public int PlayerNumber => playerNumber;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius = 0.2f;
    [SerializeField] LayerMask mask;

    [Header("Coyote Time & Jump Buffer")]
    [SerializeField] float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    [SerializeField] float jumpBufferTime = 0.2f;
    float jumpBufferCounter;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float slipFactor;

    [Header("Jump")]
    [SerializeField] float jumpForce = 200f;
    [SerializeField] int extraJumps;
    int jumpsRemaining;

    Rigidbody2D rb;
    Animator controller;
    SpriteRenderer spriteRenderer;
    Vector2 startingPos;
    bool isGrounded;
    bool isWalking;
    bool platformIsSlippery;
    float horizontalInput;

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
        // set the isGrounded variable
        IsGrounded();

        // reset the max jumps if we're grounded
        ResetCurrentJumps();

        // read player input and move 
        horizontalInput = Input.GetAxis($"P{playerNumber}Horizontal");
        if (platformIsSlippery) 
            Slip();
        else 
            MoveHorizontal();

        // coyote time and jump buffer
        IncrementCoyoteTimer();
        IncrementJumpBufferCounter();

        // flip only if we're pressing down a key
        if (horizontalInput != 0)
            spriteRenderer.flipX = horizontalInput < 0;

        // animate movement
        isWalking = horizontalInput != 0;
        UpdateAnimator();

        // checks for jumps
        if (ShouldContinueJump())
        {
            ExecuteJump();
            jumpBufferCounter = 0;
        }
        else if (ShouldDoubleJump())
        {
            ExecuteJump();
        }

        if (ShouldVariableJump())
        {
            VariableJump();
        }

    }

    void MoveHorizontal()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void Slip()
    {
        var desiredVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        var smoothedVelocity = Vector2.Lerp(
            rb.velocity, 
            desiredVelocity, 
            Time.deltaTime / slipFactor);

        rb.velocity = smoothedVelocity;
    }

    void ResetCurrentJumps()
    {
        if (isGrounded)
        {
            jumpsRemaining = extraJumps;
        }
    }

    void VariableJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        coyoteTimeCounter = 0;
    }

    bool ShouldDoubleJump() => Input.GetButtonDown($"P{playerNumber}Jump") && jumpsRemaining > 0;
    bool ShouldVariableJump() => Input.GetButtonUp($"P{playerNumber}Jump") && rb.velocity.y > 0f;
    void IsGrounded() {
        var ground = Physics2D.OverlapCircle(groundCheck.position, radius, mask); 
        isGrounded = ground;
        platformIsSlippery = ground?.CompareTag("Slippery") ?? false;
    }
    void UpdateAnimator() {
        controller.SetBool("isWalking", isWalking); 
        controller.SetBool("Jump", ShouldContinueJump());
    }

    bool ShouldContinueJump()
    {
        return coyoteTimeCounter > 0 && jumpBufferCounter > 0;
    }

    void IncrementJumpBufferCounter()
    {
        if (Input.GetButtonDown($"P{playerNumber}Jump")) 
            jumpBufferCounter = jumpBufferTime;  
        else 
            jumpBufferCounter -= Time.deltaTime;   
    }

    void IncrementCoyoteTimer()
    {
        if (isGrounded) 
            coyoteTimeCounter = coyoteTime;
        else 
            coyoteTimeCounter -= Time.deltaTime; 
    }

    public void ResetToStart()
    {
        transform.position = startingPos;
        rb.velocity = Vector2.zero;
    }

    void ExecuteJump()
    {
        jumpsRemaining--;
        rb.AddForce(Vector2.up * jumpForce); 
    }
}
