using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}
