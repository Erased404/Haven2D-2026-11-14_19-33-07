using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public Animator animP;
    public Animator animG;
    private GameObject player;
    // Update is called once per frame
    void Start()
    {
        ghostEnter();
        player = GameObject.Find("Player/Square");
        animP = player.GetComponent<Animator>();
    }

    public void ghostEnter()
    {
        animP.SetTrigger("enter");
        animG.SetTrigger("enter");
        animP.SetBool("ghostActive", false);
    }

    public void ghostExit()
    {
        animP.SetTrigger("exit");
        animG.SetTrigger("exit");
        animP.SetBool("ghostActive", true);
    }
}
