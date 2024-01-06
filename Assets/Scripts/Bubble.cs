using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bubble : BubbleAbstract
{
    [SerializeField] private GameObject _explosionSample;
    [SerializeField] private BubbleNumber _number;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Light2D _light;

    private int _size;
    private float _inertionTime;
    private float _inertionTimeCurrent;
    private Bubble _neighbour;

    private GameConfig _gameConfig;

    public void Initialize(int size, GameConfig gameConfig, bool fromMerging)
    {
        _gameConfig = gameConfig;
        _size = size;

        DefineView(_size, _gameConfig, _spriteRenderer, _number, _light);

        _inertionTime = _gameConfig.BubbleInertionTime;

        if (fromMerging == true)
        {
            GameObject explosion = Instantiate(_explosionSample, transform.position, Quaternion.identity);
            explosion.GetComponent<Explosion>().Initialize(_spriteRenderer.color);
        }
    }

    public int GetSize()
    {
        return _size;
    }

    public void FixedUpdateExtended()
    {
        if (_inertionTimeCurrent > 0)
        {
            _inertionTimeCurrent -= Time.fixedDeltaTime;
        }

        if (_neighbour != null && _inertionTimeCurrent <= 0)
        {
            Merge();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bubble>() != null && collision.collider.GetComponent<Bubble>() != this)
        {
            if (collision.collider.GetComponent<Bubble>().GetSize() == _size)
            {
                _neighbour = collision.collider.GetComponent<Bubble>();
                _inertionTimeCurrent = _inertionTime;
            }
        };
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bubble>() == _neighbour)
        {
            _neighbour = null;
        }
    }

    private void Merge()
    {
        if (_size < _gameConfig.BubbleColors.Count - 1)
        {
            Vector2 position = (transform.position + _neighbour.transform.position) / 2;
            int size = _size + 1;

            EventBus.Invoke(new BubbleMerging(position, size, this, _neighbour));
        }
    }
}
