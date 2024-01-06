using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NextBubble : BubbleAbstract
{
    [SerializeField] private BubbleNumber _number;

    private GameConfig _gameConfig;
    private SpriteRenderer _spriteRenderer;
    private TextMeshPro _numberText;
    private Light2D _light;

    private float _yMax;
    private float _xMax;
    private float _xMin;
    private float _radiusCurrent;

    private float _maxImageAlpha;
    private float _maxLightAlpha;
    private float _maxNumberAlpha;
    private float _counterMax = 1;
    private float _counterMin = -1;
    private float _counterCurrent;
    private float _blinkFrequency;

    public void Initialize(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _light = GetComponent<Light2D>();
        _numberText = _number.GetComponent<TextMeshPro>();
        _blinkFrequency = gameConfig.NextBubbleBlinkFrequency;

        _maxImageAlpha = 1;
        _maxLightAlpha = _gameConfig.BubbleLightAlpha;
        _maxNumberAlpha = BubbleCalculator.GetNumberAlpha(_spriteRenderer.color);
        _counterCurrent = _counterMax;

        _yMax = gameConfig.LowerBorderHeight - gameConfig.BorderWidth;
    }

    public void SetBorders(float xMin, float xMax)
    {
        _xMax = xMax;
        _xMin = xMin;
    }

    public void UpdateExtended()
    {
        _counterCurrent -= Time.deltaTime * _blinkFrequency;
        if (_counterCurrent < _counterMin)
        {
            _counterCurrent = _counterMax;
        }

        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _maxImageAlpha * Mathf.Abs(_counterCurrent));
        _light.color = new Color(_light.color.r, _light.color.g, _light.color.b, _maxLightAlpha * Mathf.Abs(_counterCurrent));
        _numberText.color = new Color(_numberText.color.r, _numberText.color.g, _numberText.color.b, _maxNumberAlpha * Mathf.Abs(_counterCurrent));
    }

    public void TrySetPositionX(float x)
    {
        x = Mathf.Clamp(x, _xMin + _radiusCurrent, _xMax - _radiusCurrent);
        transform.position = new Vector3(x, transform.position.y, 0);
    }

    public void Define(int size)
    {
        DefineView(size, _gameConfig, _spriteRenderer, _number, _light);

        _radiusCurrent = BubbleCalculator.GetRadius(size);
        transform.position = new Vector3(0, _yMax - _radiusCurrent);
    }
}
