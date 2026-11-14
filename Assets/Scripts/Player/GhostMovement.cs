using UnityEngine;


public class GhostMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool playerGhost=false;
    public float moveSpeed = 1000;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerGhost = !playerGhost;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveVector.y=1f * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector.y = 1f * moveSpeed;
        }
        else {
            moveVector.y = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x = 1f * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVector.x = 1f * moveSpeed;
        }
        else
        {
            moveVector.x = 0f;
        }
    }
    private Vector2 moveVector = new Vector2(0f, 0f);
    void FixedUpdate()
    {
        rb.AddForce(moveVector);

    }
}
