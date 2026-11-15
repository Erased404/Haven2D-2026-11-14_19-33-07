using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float accelSpeed = 5f;
    public float deccelSpeed = 10f;
    public KeyCode[] jumpKeys = {KeyCode.W, KeyCode.Space};
    public float jumpForce = 12f;

    public GameObject playerSpr;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;

    private Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Get horizontal direction (-1 for Left, 1 for Right, 0 for Idle)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Perform a small circle check at the player's feet to see if they are standing on the ground
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.15f, groundLayer);
        anima.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            foreach (KeyCode key in jumpKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                    anima.SetBool("Idle", false);
                    anima.SetTrigger("Jumped");
                    break; // Prevents jumping multiple times if two jump keys are pressed on the same frame
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(isGrounded);
        Vector2 movement;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            movement = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
            playerSpr.transform.localScale = new Vector3(horizontalInput * 4, playerSpr.transform.localScale.y, playerSpr.transform.localScale.z);
            anima.SetTrigger("Run");
            anima.SetBool("Idle", false);
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, movement.x, accelSpeed * Time.deltaTime);
        }
        else
        {
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, 0, deccelSpeed * Time.deltaTime);
            if (isGrounded)
            {
                anima.SetBool("Idle", true);
            }
            else
            {
                anima.SetBool("Idle", false);
            }
        }
        // Apply horizontal linearVelocity while maintaining current vertical falling/rising speed
    }
}
