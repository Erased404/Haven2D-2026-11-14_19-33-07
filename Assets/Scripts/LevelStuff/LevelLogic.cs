using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public SceneManagerScript sms;
    public int leverCount=1;
    public int currentLeverCount=0;
    public GameObject[] doors;
    public float openDuration = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sms = GetComponent<SceneManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sms.ReloadCurrentScene();
        }
    }

    public void OpenDoor(int index)
    {
        StartCoroutine(openDoor(index));
    }

    private IEnumerator openDoor(int index)
    {
        float elapsed = 0f;
        while(elapsed<openDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed/openDuration);
            doors[index].transform.localScale = Vector3.Lerp(doors[index].transform.localScale, new Vector3(1, 0, 1), t);
            yield return null;
        }
        doors[index].transform.localScale = new Vector3(1f, 0f, 1f);
    }
}
