using UnityEngine;



public class GhostMovement : MonoBehaviour
{
    public float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;
    public float accelSpeed = 10f;
    public float deccelSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal direction (-1 for Left, 1 for Right, 0 for Idle)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Apply horizontal velocity while maintaining current vertical falling/rising speed
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, movement, accelSpeed * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, movement, accelSpeed * Time.deltaTime);
        }
        else
        {
            
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, deccelSpeed * Time.deltaTime);

        }
    }
}