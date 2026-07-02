using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _raycaster.TargetDetected += HandleTargetDetected;
    }

    private void OnDisable()
    {
        _raycaster.TargetDetected -= HandleTargetDetected;
    }

    private void HandleTargetDetected(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            IReadOnlyList<Cube> fragments = _spawner.SpawnFragments(cube);
            _exploder.Explode(fragments, cube.transform.position);
        }

        _spawner.Remove(cube);
    }
}