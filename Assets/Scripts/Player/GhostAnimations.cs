using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public Animator animP;
    public Animator animG;
    // Update is called once per frame
    void Start()
    {
        ghostEnter();
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
