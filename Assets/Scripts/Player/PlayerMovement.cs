using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool playerGhost=false;
    public float moveSpeed = 1;
    private int move = 0;
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
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVector.y=1f * moveSpeed ;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveVector.x = 1f*moveSpeed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveVector.y = 1f * moveSpeed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveVector.x = 1f * moveSpeed;
        }
    }
    private Vector2 moveVector = new Vector2(0f, 0f);
    void FixedUpdate()
    {
        rb.AddForce(moveVector);
    }
}
