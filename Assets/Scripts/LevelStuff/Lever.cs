using UnityEngine;

public class Lever : MonoBehaviour
{
    public LevelLogic ll;
    public GameObject ghost;
    public int doorToOpen;
    public float canUseThreshold = 1f;
    public KeyCode openDoor = KeyCode.E;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost = GameObject.Find("Ghost");   
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, ghost.transform.position)<=canUseThreshold)
        {
            if (Input.GetKeyDown(openDoor))
            {
                ll.OpenDoor(doorToOpen);

            }
        }
    }
}
