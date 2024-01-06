using UnityEngine;

public class LowerTrigger : MonoBehaviour
{
    private bool _isCollided;
    private float _timeToGameOver = 10;
    private float _timeToGameOverCurrent;

    public void Initialize(GameConfig gameConfig)
    {
        _timeToGameOver = gameConfig.TimeToGameOver;
        _timeToGameOverCurrent = 0;
        _isCollided = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>() != null)
        {
            _isCollided = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isCollided == true)
        {
            _timeToGameOverCurrent += Time.fixedDeltaTime;
        }
        else
        {
            _timeToGameOverCurrent = 0;
        }

        _isCollided = false;

        if (_timeToGameOverCurrent >= _timeToGameOver)
        {
            EventBus.Invoke(new GameOver());
        }
    }
}
