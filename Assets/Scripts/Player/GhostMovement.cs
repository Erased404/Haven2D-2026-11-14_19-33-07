using UnityEngine;



public class GhostMovement : MonoBehaviour
{
    public float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    public float accelSpeed = 10f;
    public float deccelSpeed = 5f;

    public GameObject playerSpr;

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
            if (horizontalInput != 0)
            {
                playerSpr.transform.localScale = new Vector3(horizontalInput * 3, playerSpr.transform.localScale.y, playerSpr.transform.localScale.z);
            }
            else
            {
                playerSpr.transform.localScale = new Vector3(3, playerSpr.transform.localScale.y, playerSpr.transform.localScale.z);
            }
            
        }
        else
        {
            
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, deccelSpeed * Time.deltaTime);

        }
    }
}