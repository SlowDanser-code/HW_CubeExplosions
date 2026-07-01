using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const float ScaleMultiplier = 0.5f;

    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minimumCubeCount = 2;
    [SerializeField] private int _maximumCubeCount = 6;

    [SerializeField] private float _spawnRadius = 0.5f;
    [SerializeField]
    private Vector3 _spawnPosition = new(0f, 4f, 0f);

    private void Start()
    {
        Spawn(_spawnPosition, Vector3.one, 1f);
    }

    public List<Cube> Spawn(Cube parentCube)
    {
        List<Cube> cubes = new();

        int cubeCount = Random.Range(
            _minimumCubeCount,
            _maximumCubeCount + 1);

        float splitChance =
            parentCube.SplitChance * ScaleMultiplier;

        Vector3 cubeScale =
            parentCube.transform.localScale * ScaleMultiplier;

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 position =
                parentCube.transform.position +
                Random.insideUnitSphere * _spawnRadius;

            Cube cube = Spawn(
                position,
                cubeScale,
                splitChance);

            cubes.Add(cube);
        }

        return cubes;
    }

    public Cube Spawn(Vector3 position, Vector3 scale, float splitChance)
    {
        Cube cube = Instantiate(
            _cubePrefab,
            position,
            Random.rotation);

        cube.transform.localScale = scale;

        cube.Initialize(splitChance);

        cube.Visual.SetRandomColor();

        return cube;
    }
}