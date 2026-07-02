using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _selectionButtonIndex = 0;

    public event Action<Vector2> SelectionRequested;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_selectionButtonIndex))
            SelectionRequested?.Invoke(Input.mousePosition);
    }
}