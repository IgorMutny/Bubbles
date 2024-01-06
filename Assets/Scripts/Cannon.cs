using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private NextBubble _nextBubble;

    private int _minSize;
    private int _maxSize;
    private int _nextBubbleSize;

    private float _coolDown;
    private bool _canShoot = false;

    private float _yMin;
    private BoxCollider2D _collider;

    private bool _oneClickHandle;
    private bool _mouseIsPressed;

    public void Initialize(GameConfig gameConfig)
    {
        _oneClickHandle = YG.YandexGame.savesData.OneClickHandle;

        _minSize = gameConfig.MinSize;
        _maxSize = gameConfig.MaxSize;
        _coolDown = gameConfig.CoolDown;
        Invoke(nameof(AllowShoot), _coolDown);
        DefineNextBubble();

        EventBus.Subscribe<ControlsToggled>(OnControlsToggled);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<ControlsToggled>(OnControlsToggled);
    }

    private void OnControlsToggled(ControlsToggled e)
    {
        _oneClickHandle = e.OneClickHandle;
    }

    public void SetSize(float xMax, float xMin, float yMax, float yMin)
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = new Vector2(xMax - xMin, yMax - yMin);
        _collider.offset = new Vector2(0, (yMax + yMin) / 2);
        _yMin = yMin;
    }

    public void UpdateExtended()
    {
        if (_oneClickHandle == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _nextBubble.TrySetPositionX(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                TryShoot();
                _nextBubble.TrySetPositionX(0);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (MouseIsInCollider() == true)
                {
                    _mouseIsPressed = true;
                }
            }

            if (_mouseIsPressed == true)
            {
                _nextBubble.TrySetPositionX(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            }

            if (Input.GetMouseButtonUp(0) && _mouseIsPressed == true)
            {
                TryShoot();
                _nextBubble.TrySetPositionX(0);
                _mouseIsPressed = false;
            }
        }
    }

    private void TryShoot()
    {
        if (_canShoot == true)
        {
            if (MouseIsInCollider() == true)
            {
                Shoot();
                _nextBubble.gameObject.SetActive(false);
            }
        }
    }

    private bool MouseIsInCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D[] _colliders = Physics2D.OverlapPointAll(mousePosition);
        foreach (Collider2D collider in _colliders)
        {
            if (collider == _collider)
            {
                return true;
            }
        }

        return false;
    }

    private void Shoot()
    {
        Vector2 bubblePosition = _nextBubble.transform.position;

        EventBus.Invoke(new BubbleCreating(bubblePosition, _nextBubbleSize));

        DefineNextBubble();
        _canShoot = false;
        Invoke(nameof(AllowShoot), _coolDown);
    }

    private void AllowShoot()
    {
        _canShoot = true;
        _nextBubble.gameObject.SetActive(true);
    }

    private void DefineNextBubble()
    {
        _nextBubbleSize = Random.Range(_minSize, _maxSize + 1);
        _nextBubble.Define(_nextBubbleSize);
    }
}
