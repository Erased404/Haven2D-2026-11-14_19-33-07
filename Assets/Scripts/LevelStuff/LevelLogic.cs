using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public int leverCount=0;
    public int currentLeverCount;
    public GameObject[] doors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(currentLeverCount!=leverCount)
        {
            OpenDoor(0);
        }
    }

    void OpenDoor(int index)
    {
        GameObject door = GameObject.Find(name);
        if (door.transform.localScale.y >= 0.025)
        { 
            door.transform.localScale = Vector3.Lerp(door.transform.localScale, new Vector3(1, 0, 1), 0.5f * Time.fixedDeltaTime);        }
        else
        {
            door.transform.localScale = new Vector3(1, 0, 1);
            //currentLeverCount++;
        }
    }
}
