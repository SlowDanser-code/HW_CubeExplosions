using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Visual))]
public class Cube : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _splitChance = 1f;

    private Rigidbody _rigidbody;
    private Visual _visual;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;
    public Visual Visual => _visual;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _visual = GetComponent<Visual>();
    }

    public void Initialize(float splitChance)
    {
        _splitChance = splitChance;
    }
}