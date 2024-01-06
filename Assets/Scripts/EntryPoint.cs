using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Resizer _resizer;
    [SerializeField] private Cannon _cannon;
    [SerializeField] private AdHandler _adHandler;
    [SerializeField] private GamePlayHandler _gamePlayHandler;
    [SerializeField] private BubbleCreator _bubbleCreator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private UIScore _uiScore;
    [SerializeField] private UIHiScore _uiHiScore;
    [SerializeField] private NextBubble _nextBubble;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private BackSoundHandler _backSoundHandler;
    [SerializeField] private ButtonSoundHandler _buttonSoundHandler;
    [SerializeField] private LowerTrigger _lowerTrigger;
    [SerializeField] private UIControls _uiControls;

    private bool SDKEnabled = false;

    private void Update()
    {
        if (YG.YandexGame.SDKEnabled == true && SDKEnabled == false)
        {
            SDKEnabled = true;
            StartExtended();
        }
    }

    private void StartExtended()
    {
        Application.targetFrameRate = 60;

        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);

        _resizer.Initialize(_gameConfig);

        _nextBubble.Initialize(_gameConfig);

        _cannon.Initialize(_gameConfig);

        _adHandler.Initialize(_gameConfig);
        _gamePlayHandler.Initialize(_scoreCounter);
        _bubbleCreator.Initialize(_gameConfig);
        _lowerTrigger.Initialize(_gameConfig);

        _uiScore.Initialize();
        _uiHiScore.Initialize();
        _scoreCounter.Initialize();
        _uiControls.Initialize();

        _backSoundHandler.Initialize();
        _buttonSoundHandler.Initialize();

        EventBus.Invoke(new PauseSwitched(false));

        _nextBubble.gameObject.SetActive(false);
    }
}
