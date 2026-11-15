using UnityEngine;

public class END : MonoBehaviour
{
    private GameObject Global;
    private SceneManagerScript sms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Global = GameObject.Find("Global");
    }

    // Update is called once per frame
    void Update()
    {
        sms = Global.GetComponent<SceneManagerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sms.LoadNextScene();
    }
}
