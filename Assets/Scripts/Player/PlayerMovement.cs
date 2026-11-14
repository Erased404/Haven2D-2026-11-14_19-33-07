using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float accelSpeed = 5f;
    public float deccelSpeed = 10f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal direction (-1 for Left, 1 for Right, 0 for Idle)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Perform a small circle check at the player's feet to see if they are standing on the ground
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.15f, groundLayer);

        // Jump trigger (Checked in Update so keypresses aren't missed)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(isGrounded);
        Vector2 movement;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            movement = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, movement.x, accelSpeed * Time.deltaTime);
        }
        else
        {
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, deccelSpeed * Time.deltaTime);
        }
        // Apply horizontal linearVelocity while maintaining current vertical falling/rising speed
    }
}
