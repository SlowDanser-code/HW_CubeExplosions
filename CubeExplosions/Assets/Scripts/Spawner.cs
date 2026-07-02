using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float InitialSplitChance = 1f;

    [SerializeField] private Cube _prefab;
    [SerializeField] private Vector3 _firstCubePosition = new Vector3(0f, 4f, 0f);
    [SerializeField] private Vector3 _firstCubeScale = Vector3.one;

    [SerializeField] private int _minimumAmount = 2;
    [SerializeField] private int _maximumAmount = 6;
    [SerializeField] private float _spreadRadius = 0.5f;
    [SerializeField] private float _scaleMultiplier = 0.5f;
    [SerializeField] private float _splitChanceMultiplier = 0.5f;

    private void Start()
    {
        Spawn(_firstCubePosition, _firstCubeScale, InitialSplitChance);
    }

    public IReadOnlyList<Cube> SpawnFragments(Cube source)
    {
        List<Cube> fragments = new List<Cube>();
        int amount = Random.Range(_minimumAmount, _maximumAmount + 1);
        Vector3 scale = source.transform.localScale * _scaleMultiplier;
        float splitChance = source.SplitChance * _splitChanceMultiplier;

        for (int i = 0; i < amount; i++)
        {
            Vector3 position = source.transform.position + Random.insideUnitSphere * _spreadRadius;
            Cube fragment = Spawn(position, scale, splitChance);
            fragments.Add(fragment);
        }

        return fragments;
    }

    public void Remove(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private Cube Spawn(Vector3 position, Vector3 scale, float splitChance)
    {
        Cube cube = Instantiate(_prefab, position, Random.rotation);
        cube.transform.localScale = scale;
        cube.Initialize(splitChance);
        cube.Visual.SetRandomColor();

        return cube;
    }
}