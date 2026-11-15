using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class LazerHandler : MonoBehaviour
{
    public GameObject gm;
    public GhostMovement gmS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("Ghost");
        gmS = gm.GetComponent<GhostMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("e");
        if (collision.gameObject.name == "Ghost")
        {
            GameObject c1=collision.gameObject;
            Debug.Log(c1);
            Rigidbody2D rb = c1.GetComponent<Rigidbody2D>();
            
                rb.linearVelocity = Vector2.zero; // Use rb.velocity in Unity 2022 or older
                
            
        }
    }
}
