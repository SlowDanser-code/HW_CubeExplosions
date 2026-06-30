using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeVisual : MonoBehaviour
{
    [SerializeField] private Renderer cubeRenderer;

    private void Awake()
    {
        if (cubeRenderer == null)
            cubeRenderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        cubeRenderer.material.color = new Color(
            Random.value,
            Random.value,
            Random.value);
    }
}