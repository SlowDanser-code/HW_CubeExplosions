using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Visual : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Vector2 _hueRange = new Vector2(0f, 1f);
    [SerializeField] private Vector2 _saturationRange = new Vector2(0.6f, 1f);
    [SerializeField] private Vector2 _valueRange = new Vector2(0.6f, 1f);

    private void Awake()
    {
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        float hue = Random.Range(_hueRange.x, _hueRange.y);
        float saturation = Random.Range(_saturationRange.x, _saturationRange.y);
        float value = Random.Range(_valueRange.x, _valueRange.y);

        _renderer.material.color = Random.ColorHSV(hue, hue, saturation, saturation, value, value);
    }
}