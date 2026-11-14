using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool playerGhost=false;
    private int move = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            playerGhost = !playerGhost;
        }
    }

    void FixedUpdate()
    {
        Vector2 myPosition = new Vector2(5.5f, 2.0f);
        if (move!=0)
        {
            rb.AddForce
        }
    }
}
