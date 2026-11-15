using UnityEngine;

public class GhostWall : MonoBehaviour
{
    public Material normalMat;
    public Material phaseMat;
    public Renderer thisRenderer;
    Transform ghost;
    [SerializeField] private float threshold = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRenderer = GetComponentInChildren<Renderer>();
        ghost = GameObject.Find("Ghost").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, ghost.position) <= threshold)
        {
            thisRenderer.material = phaseMat;
        }
        else
        {
            thisRenderer.material = normalMat;
        }
    }
}
