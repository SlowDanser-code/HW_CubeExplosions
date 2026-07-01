using System;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private InputReader _inputReader;

    public event Action<Cube> CubeClicked;

    private void Awake()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    private void OnEnable()
    {
        _inputReader.LeftMouseButtonClicked += OnMouseClicked;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseButtonClicked -= OnMouseClicked;
    }

    private void OnMouseClicked(Vector2 mousePosition)
    {
        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeClicked?.Invoke(cube);
            }
        }
    }
}