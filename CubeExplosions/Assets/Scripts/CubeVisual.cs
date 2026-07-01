using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeVisual : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void Awake()
    {
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV(
            0f, 1f,
            0.6f, 1f,
            0.6f, 1f);
    }
}