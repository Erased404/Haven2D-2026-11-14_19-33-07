using UnityEngine;
using System.Collections;

public class PersonaSwitch : MonoBehaviour
{
    public GameObject pm;
    public GameObject gm;
    public PlayerMovement pmS;
    public GhostMovement gmS;
    public GameObject gameCamera;
    public bool GhostEnabled = false;
    public KeyCode switchKey = KeyCode.Q;
    public float switchSpeed = 5f;
    public float returnThreshold = 1.5f;

    public GhostAnimations anim;

    public int fpsLimit = 60;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = fpsLimit;
        gameCamera = GameObject.Find("Main Camera");
        pm = GameObject.Find("Player");
        gm = GameObject.Find("Ghost");
        pmS = pm.GetComponent<PlayerMovement>();
        gmS = gm.GetComponent<GhostMovement>();
        anim = gm.GetComponent<GhostAnimations>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(switchKey))
        {
            GhostEnabled = !GhostEnabled;
            if (GhostEnabled)
            {
                anim.ghostExit();
            }
            else
            {
                anim.ghostEnter();
            }
        }
        if (GhostEnabled)
        {
            pm.GetComponent<BoxCollider2D>().enabled = false;
            gm.GetComponent<BoxCollider2D>().enabled = true; 
            pmS.enabled = false;
            gmS.enabled = true;
            gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(gm.transform.position.x, gm.transform.position.y, -1f), switchSpeed * Time.deltaTime);
        }
        else
        {
            pm.GetComponent<BoxCollider2D>().enabled = true;
            gmS.enabled = false;
            pmS.enabled = true;
            gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(pm.transform.position.x, pm.transform.position.y, -1f), switchSpeed * Time.deltaTime);
            if (Vector2.Distance(gm.transform.position, pm.transform.position) > returnThreshold)
            {
                gm.transform.position = Vector3.Lerp(gm.transform.position, new Vector3(pm.transform.position.x, pm.transform.position.y + 1, 0), switchSpeed * Time.deltaTime);
            }
            else 
            { 
                gm.GetComponent<BoxCollider2D>().enabled = false; 
            }
        }
    }
}
