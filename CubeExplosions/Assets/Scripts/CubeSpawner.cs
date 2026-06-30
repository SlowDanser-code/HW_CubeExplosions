using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Cube cubePrefab;

    [Header("Start Cube")]
    [SerializeField] private Vector3 startPosition = new Vector3(0, 5, 0);

    [Header("Split")]
    [SerializeField] private int minCubeCount = 2;
    [SerializeField] private int maxCubeCount = 6;

    [SerializeField] private float spawnRadius = 0.3f;

    [Header("Explosion")]
    [SerializeField] private float explosionForce = 7f;
    [SerializeField] private float explosionRadius = 3f;

    private void Start()
    {
        SpawnStartCube();
    }

    private void SpawnStartCube()
    {
        Cube cube = Instantiate(
            cubePrefab,
            startPosition,
            Random.rotation);

        cube.Initialize(this, 1f);

        cube.Visual.SetRandomColor();
    }

    public void Split(Cube parentCube)
    {
        int cubeCount = Random.Range(minCubeCount, maxCubeCount + 1);

        Vector3 position = parentCube.transform.position;

        Vector3 newScale =
            parentCube.transform.localScale * 0.5f;

        float newChance =
            parentCube.SplitChance * 0.5f;

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 spawnPosition =
                position + Random.insideUnitSphere * spawnRadius;

            Cube cube = Instantiate(
                cubePrefab,
                spawnPosition,
                Random.rotation);

            cube.transform.localScale = newScale;

            cube.Initialize(this, newChance);

            cube.Visual.SetRandomColor();

            cube.Rigidbody.AddExplosionForce(
                explosionForce,
                position,
                explosionRadius,
                0.5f,
                ForceMode.Impulse);
        }
    }
}