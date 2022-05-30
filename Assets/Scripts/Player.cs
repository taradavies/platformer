using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator controller;
    [SerializeField] float moveSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        bool isWalking = horizontalInput!=0;
        controller.SetBool("isWalking", isWalking);
    }
}
