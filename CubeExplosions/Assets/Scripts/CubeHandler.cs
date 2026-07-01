using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeRaycaster _cubeRaycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;

    private void OnEnable()
    {
        _cubeRaycaster.CubeClicked += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _cubeRaycaster.CubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var cubes = _cubeSpawner.Spawn(cube);

            _cubeExploder.Explode(
                cubes,
                cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}