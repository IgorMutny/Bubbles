using UnityEngine;
using YG;

public class AdHandler : MonoBehaviour
{
    [SerializeField] private GameObject _adWarningSample;

    private float _adWarningLifeTime;
    private float _adTimeCounter;

    private AdWarning _adWarning;
    private float _adTimeCounterCurrent;
    private bool _isPaused = true;

    public void Initialize(GameConfig gameConfig)
    {
        _adWarningLifeTime = gameConfig.AdWarningLifeTime;
        _adTimeCounter = gameConfig.AdTimeCounter;

        EventBus.Subscribe<PauseSwitched>(OnPauseSwitched);
        YandexGame.CloseFullAdEvent += RestartCounter;

        RestartCounter();
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<PauseSwitched>(OnPauseSwitched);
    }

    private void Update()
    {
        if (_isPaused == false && _adWarning == null)
        {
            _adTimeCounterCurrent -= Time.unscaledDeltaTime;

            if (_adTimeCounterCurrent < _adWarningLifeTime)
            {
                _adWarning = Instantiate(_adWarningSample, Vector2.zero, Quaternion.identity).GetComponent<AdWarning>();
                _adWarning.Initialize(_adWarningLifeTime);
                EventBus.Invoke(new PauseSwitched(true));
            }
        }

        if (_isPaused == true && _adWarning != null)
        {
            _adTimeCounterCurrent -= Time.unscaledDeltaTime;

            if (_adTimeCounterCurrent <= 0)
            {
                Destroy(_adWarning.gameObject);
                ShowAd();
            }
        }
    }

    private void OnPauseSwitched(PauseSwitched e)
    {
        _isPaused = e.State;
    }

    private void ShowAd()
    {
        YandexGame.FullscreenShow();
    }

    private void RestartCounter()
    {
        _adTimeCounterCurrent = _adTimeCounter;
        EventBus.Invoke(new PauseSwitched(false));
    }
}
