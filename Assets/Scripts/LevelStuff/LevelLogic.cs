using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public int leverCount=1;
    public int currentLeverCount=0;
    public GameObject[] doors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoor(int index)
    {
        if (doors[index].transform.localScale.y <= 0.02)
        {
            doors[index].transform.localScale = new Vector3(1, 0, 1);
            currentLeverCount++;
        }
        else
        {
            doors[index].transform.localScale = Vector3.Lerp(doors[index].transform.localScale, new Vector3(1, 0, 1), 1.5f * Time.fixedDeltaTime);
        }
    }
}
