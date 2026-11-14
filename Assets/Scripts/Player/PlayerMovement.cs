using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float decelSpeed = 20f;
    float moveVector;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(moveVector)==0)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, decelSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * (moveVector * moveSpeed));
    }
}
