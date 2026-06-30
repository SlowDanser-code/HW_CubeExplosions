using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubeVisual))]
public class Cube : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    private float splitChance = 1f;

    private CubeSpawner spawner;
    private Rigidbody rb;
    private CubeVisual visual;

    public Rigidbody Rigidbody => rb;
    public CubeVisual Visual => visual;
    public float SplitChance => splitChance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        visual = GetComponent<CubeVisual>();
    }

    public void Initialize(CubeSpawner cubeSpawner, float chance)
    {
        spawner = cubeSpawner;
        splitChance = chance;
    }

    private void OnMouseDown()
    {
        if (Random.value <= splitChance)
        {
            spawner.Split(this);
        }

        Destroy(gameObject);
    }
}