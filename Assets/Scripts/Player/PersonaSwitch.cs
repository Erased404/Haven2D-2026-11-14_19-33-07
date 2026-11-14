using UnityEngine;

public class PersonaSwitch : MonoBehaviour
{
    public GameObject pm;
    public GameObject gm;
    public PlayerMovement pmS;
    public GhostMovement gmS;
    public GameObject gameCamera;
    public bool GhostEnabled=false;
    public KeyCode switchKey = KeyCode.Q;
    public float switchSpeed = 5f;

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
        if(Input.GetKeyUp(switchKey))
        {
            GhostEnabled = !GhostEnabled;
        }
        if (GhostEnabled)
        {
            pmS.enabled = false;
            gmS.enabled = true;
            gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(gm.transform.position.x, gm.transform.position.y, -1f), switchSpeed * Time.deltaTime);
        }
        else
        {
            gmS.enabled = false;
            pmS.enabled = true;
            gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(pm.transform.position.x, pm.transform.position.y, -1f), switchSpeed * Time.deltaTime);

        }
    }
}
