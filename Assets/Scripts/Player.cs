using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Number")]
    [SerializeField] [Range(1,2)] int playerNumber = 1;
    public int PlayerNumber => playerNumber;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius = 0.2f;
    [SerializeField] LayerMask groundMask;

    [Header("Wall Slide")]
    [SerializeField] LayerMask wallMask;
    [SerializeField] float distanceFromWall = 0.02f;
    [SerializeField] Transform rightWallSensor;
    [SerializeField] Transform leftWallSensor;
    [SerializeField] float wallSlideSpeed = 2f;
    [SerializeField] float wallJumpVerticalVelocity = 5f;
    [SerializeField] float wallJumpHorizontalVelocity = 5f;

    [Header("Coyote Time")]
    [SerializeField] float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float slipFactor;
    [SerializeField] float acceleration = 25f;
    [SerializeField] float deceleration = 25f;
    [SerializeField] float airDeceleration;
    [SerializeField] float airAcceleration;

    [Header("Jump")]
    [SerializeField] float jumpForce = 200f;
    [SerializeField] int extraJumps;
    int jumpsRemaining;

    Rigidbody2D rb;
    Animator controller;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    Vector2 startingPos;
    float horizontalInput;
    bool isGrounded;
    bool isOnWall;
    bool isWalking;
    bool platformIsSlippery;
    string horizontalInputAxes;
    string jumpInputAxes;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start() {
        startingPos = transform.position;
        jumpsRemaining = extraJumps;
        horizontalInputAxes = $"P{playerNumber}Horizontal";
        jumpInputAxes = $"P{playerNumber}Jump";
    }
    void Update()
    {
        // set the isGrounded variable
        IsGrounded();

        // reset the max jumps if we're grounded
        ResetCurrentJumps();

        // read player input and move 
        horizontalInput = Input.GetAxis(horizontalInputAxes);
        
        if (platformIsSlippery) 
            Slip();
        else if (ShouldSlide()) 
        {
            if (ShouldStartJump()) {
                WallJump();
            }
            else {
                Slide();   
            }
        }
        else 
            MoveHorizontal();

        // coyote time and jump buffer
        
        IncrementCoyoteTimer();

        // flip only if we're pressing down a key
        if (horizontalInput != 0)
            spriteRenderer.flipX = horizontalInput < 0;

        // animate movement
        isWalking = horizontalInput != 0;
        UpdateAnimator();

        // checks for jumps
        if (ShouldStartJump())
        {
            ExecuteJump();
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

    void WallJump()
    {
        Debug.Log("Wall jump");
        jumpsRemaining--;
        rb.velocity = new Vector2(wallJumpHorizontalVelocity * -horizontalInput, wallJumpVerticalVelocity);
    }

    private void Slide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        UpdateAnimator();
    }

    private bool ShouldSlide()
    {
        if (isGrounded) {
            return false;
        }

        // allows for wall jump
        if (rb.velocity.y > 0) {
            return false;
        }

        if (horizontalInput > 0) {
            var rightWallSensorHit = Physics2D.OverlapCircle(rightWallSensor.position, distanceFromWall, wallMask);
            isOnWall = rightWallSensorHit != null;
            return isOnWall;
        }
        else if (horizontalInput < 0) {
            var leftWallSensorHit = Physics2D.OverlapCircle(leftWallSensor.position, distanceFromWall, wallMask);
            isOnWall = leftWallSensorHit != null;
            return isOnWall;
        }
        return false;
    }

    void MoveHorizontal()
    {
        float tightControlMultiplier = horizontalInput == 0 ? deceleration : acceleration;

        if (!isGrounded) {
            tightControlMultiplier = horizontalInput == 0 ? airDeceleration : airAcceleration;
        }
        
        var newHorizontal = Mathf.Lerp(
            rb.velocity.x,
            horizontalInput * moveSpeed,
            Time.deltaTime * tightControlMultiplier);

        rb.velocity = new Vector2(newHorizontal, rb.velocity.y);
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
        if (isGrounded || isOnWall)
        {
            jumpsRemaining = extraJumps;
        }
    }

    void VariableJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        coyoteTimeCounter = 0;
    }

    bool ShouldDoubleJump() => Input.GetButtonDown(jumpInputAxes) && jumpsRemaining > 0;
    bool ShouldVariableJump() => Input.GetButtonUp(jumpInputAxes) && rb.velocity.y > 0f;
    void IsGrounded() {
        var ground = Physics2D.OverlapCircle(groundCheck.position, radius, groundMask); 
        isGrounded = ground;
        platformIsSlippery = ground?.CompareTag("Slippery") ?? false;
    }
    void UpdateAnimator() {
        controller.SetBool("isWalking", isWalking); 
        controller.SetBool("Jump", ShouldStartJump());
        controller.SetBool("Slide", ShouldSlide());
    }

    bool ShouldStartJump()
    {
        return coyoteTimeCounter > 0 && Input.GetButtonDown(jumpInputAxes);
    }

    void IncrementCoyoteTimer()
    {
        if (isGrounded || isOnWall) 
            coyoteTimeCounter = coyoteTime;
        else 
            coyoteTimeCounter -= Time.deltaTime; 
    }

    void ExecuteJump()
    {
        jumpsRemaining--;
        if (jumpsRemaining < 0) {return;}
        if (audioSource != null) {
            audioSource.Play();
        }
        rb.AddForce(Vector2.up * jumpForce); 
    }

    public void ResetToStart()
    {
        rb.position = startingPos;
        rb.velocity = Vector2.zero;
    }
    public void TeleportTo(Vector3 position) {
        rb.position = position;
        rb.velocity = Vector2.zero;
    }
}
