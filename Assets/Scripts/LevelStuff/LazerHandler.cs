using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class LazerHandler : MonoBehaviour
{
    public GameObject pm;
    public GameObject gm;
    public PlayerMovement pmS;
    public GhostMovement gmS;
    public GameObject gameCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        pm = GameObject.Find("Player");
        gm = GameObject.Find("Ghost");
        pmS = pm.GetComponent<PlayerMovement>();
        gmS = gm.GetComponent<GhostMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        personaSwitch.enabled = true; 

    }

    [SerializeField] public PersonaSwitch personaSwitch;

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("e");
        if (collision.gameObject.name == "Ghost")
        {
            GameObject c1=collision.gameObject;
            Debug.Log(c1);
            Rigidbody2D rb = c1.GetComponent<Rigidbody2D>();
            
            rb.linearVelocity = Vector2.zero; // Use rb.velocity in Unity 2022 or older
            
            personaSwitch.enabled = false;
            gmS.enabled = true;
            pmS.enabled = false;
            personaSwitch.GhostEnabled = true;



        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ghost")
        {
            GameObject c1 = collision.gameObject;
            Debug.Log(c1);
            Rigidbody2D rb = c1.GetComponent<Rigidbody2D>();

            rb.linearVelocity = Vector2.zero;
            personaSwitch.enabled = false;
            gmS.enabled = true;
            pmS.enabled = false;
            personaSwitch.GhostEnabled = true;
        }
        

    }
    //{
    //Debug.Log("1");
    //
    //}
}
