using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 8f;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _upwardModifier = 0.5f;

    public void Explode(
        IReadOnlyList<Cube> cubes,
        Vector3 explosionPosition)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(
                _explosionForce,
                explosionPosition,
                _explosionRadius,
                _upwardModifier,
                ForceMode.Impulse);
        }
    }
}