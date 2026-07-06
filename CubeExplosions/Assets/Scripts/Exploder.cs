using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private const float MinimumScale = 0.01f;

    [SerializeField] private float _force = 8f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _upwardModifier = 0.5f;
    [SerializeField] private float _referenceScale = 1f;

    public void Explode(IReadOnlyList<Cube> targets, Vector3 position)
    {
        foreach (Cube target in targets)
            target.Rigidbody.AddExplosionForce(_force, position, _radius, _upwardModifier, ForceMode.Impulse);
    }

    public void Explode(Cube source)
    {
        Vector3 position = source.transform.position;
        float scaleMultiplier = GetScaleMultiplier(source);
        float force = _force * scaleMultiplier;
        float radius = _radius * scaleMultiplier;
        Collider[] colliders = Physics.OverlapSphere(position, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Cube target) && target != source)
                target.Rigidbody.AddExplosionForce(force, position, radius, _upwardModifier, ForceMode.Impulse);
        }
    }

    private float GetScaleMultiplier(Cube cube)
    {
        Vector3 scale = cube.transform.localScale;
        float largestSide = Mathf.Max(scale.x, scale.y, scale.z);

        return _referenceScale / Mathf.Max(largestSide, MinimumScale);
    }
}
