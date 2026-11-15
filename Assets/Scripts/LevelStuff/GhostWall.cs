using UnityEngine;

public class GhostWall : MonoBehaviour
{
    public Material normalMat;
    public Material phaseMat;
    private Renderer renderer;
    Transform ghost;
    [SerializeField] private float threshold = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost = GameObject.Find("Ghost").transform;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, ghost.position) <= threshold)
        {
            renderer.material = phaseMat;
        }
        else
        {
            renderer.material = normalMat;
        }
    }
}
