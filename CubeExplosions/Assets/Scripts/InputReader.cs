using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> LeftMouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonClicked?.Invoke(Input.mousePosition);
        }
    }
}