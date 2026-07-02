using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 8f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _upwardModifier = 0.5f;

    public void Explode(IReadOnlyList<Cube> targets, Vector3 position)
    {
        foreach (Cube target in targets)
            target.Rigidbody.AddExplosionForce(_force, position, _radius, _upwardModifier, ForceMode.Impulse);
    }
}