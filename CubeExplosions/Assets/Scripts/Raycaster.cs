using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _maxDistance = 100f;

    public event Action<Cube> TargetDetected;

    private void Awake()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    private void OnEnable()
    {
        _inputReader.SelectionRequested += DetectTarget;
    }

    private void OnDisable()
    {
        _inputReader.SelectionRequested -= DetectTarget;
    }

    private void DetectTarget(Vector2 screenPosition)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance) && hit.collider.TryGetComponent(out Cube cube))
            TargetDetected?.Invoke(cube);
    }
}