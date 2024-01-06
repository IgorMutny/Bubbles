using UnityEngine;

public class Resizer : MonoBehaviour
{
    [SerializeField] private GameObject _back;
    [SerializeField] private GameObject _upper;
    [SerializeField] private GameObject _lower;
    [SerializeField] private GameObject _right;
    [SerializeField] private GameObject _left;
    [SerializeField] private NextBubble _nextBubble;

    [SerializeField] private Cannon _cannon;
    [SerializeField] private Canvas _canvas;

    private GameConfig _gameConfig;

    private Vector2 _point0;
    private Vector2 _point1;
    private float _xMax;
    private float _yMax;
    private float _xMin;
    private float _yMin;
    private float _yBorderMin;

    private float _maximalWidthToHeightRatio;

    public void Initialize(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
        _maximalWidthToHeightRatio = _gameConfig.MaximalWidthToHeightRatio;

        Resize();
    }

    private void Resize()
    {
        _point0 = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _point1 = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        SetMinMaxCoords(_point0, _point1);

        _cannon.SetSize(_xMax, _xMin, _yMax, _yBorderMin);

        SetBorders();

        _back.GetComponent<SpriteRenderer>().size = new Vector2(_xMax - _xMin, _yMax - _yMin);
        _canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(_xMax - _xMin, _yMax - _yMin);

        _nextBubble.SetBorders(_xMin, _xMax);
    }

    private void SetBorders()
    {
        float width = _gameConfig.BorderWidth;

        _upper.transform.position = new Vector2(0, _yMax + width / 2);
        _upper.GetComponent<BoxCollider2D>().size = new Vector2(_xMax - _xMin, width);
        _upper.GetComponent<SpriteRenderer>().size = new Vector2(_xMax - _xMin, width);

        _right.transform.position = new Vector2(_xMin - width / 2, 0);
        _right.GetComponent<BoxCollider2D>().size = new Vector2(width, _yMax - _yMin + width * 2);
        _right.GetComponent<SpriteRenderer>().size = new Vector2(width, _yMax - _yMin + width * 2);

        _left.transform.position = new Vector2(_xMax + width / 2, 0);
        _left.GetComponent<BoxCollider2D>().size = new Vector2(width, _yMax - _yMin + width * 2);
        _left.GetComponent<SpriteRenderer>().size = new Vector2(width, _yMax - _yMin + width * 2);

        _lower.transform.position = new Vector2(0, _yBorderMin - width / 2);
        _lower.GetComponent<BoxCollider2D>().size = new Vector2(_xMax - _xMin, width);
        _lower.GetComponent<SpriteRenderer>().size = new Vector2(_xMax - _xMin, width);
    }

    private void SetMinMaxCoords(Vector2 point0, Vector2 point1)
    {
        _xMax = Mathf.Max(point0.x, point1.x);
        _xMin = Mathf.Min(point0.x, point1.x);
        _yMax = Mathf.Max(point0.y, point1.y);
        _yMin = Mathf.Min(point0.y, point1.y);
        _yBorderMin = _gameConfig.LowerBorderHeight;

        float proportion = (_xMax - _xMin) / (_yMax - _yMin);
        if (proportion > _maximalWidthToHeightRatio)
        {
            _xMax = _yMax * _maximalWidthToHeightRatio;
            _xMin = - _yMax * _maximalWidthToHeightRatio;
        }
    }

    private void Update()
    {
        Vector2 point0 = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 point1 = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (point0 != _point0 || point1 != _point1)
        {
            Resize();
        }
    }
}
