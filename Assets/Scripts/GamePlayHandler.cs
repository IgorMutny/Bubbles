using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GamePlayHandler : MonoBehaviour
{
    [SerializeField] private Cannon _cannon;
    [SerializeField] private NextBubble _nextBubble;
    [SerializeField] private GameOverMenu _gameOverMenu;

    private List<Bubble> _bubbles = new();

    private bool _isPaused = true;
    private ScoreCounter _scoreCounter;

    public void Initialize(ScoreCounter scoreCounter)
    {
        EventBus.Subscribe<PauseSwitched>(OnPauseSwitched);
        EventBus.Subscribe<GameRestarted>(OnGameRestarted);
        EventBus.Subscribe<GameOver>(OnGameOver);
        EventBus.Subscribe<BubbleCreated>(OnBubbleCreated);
        EventBus.Subscribe<BubbleMerged>(OnBubbleMerged);

        _scoreCounter = scoreCounter;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<PauseSwitched>(OnPauseSwitched);
        EventBus.Unsubscribe<GameRestarted>(OnGameRestarted);
        EventBus.Unsubscribe<GameOver>(OnGameOver);
        EventBus.Unsubscribe<BubbleCreated>(OnBubbleCreated);
        EventBus.Unsubscribe<BubbleMerged>(OnBubbleMerged);
    }

    private void OnPauseSwitched(PauseSwitched e)
    {
        if (e.State == true)
        {
            PauseGame();
        }

        if (e.State == false)
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0;

        foreach (Bubble bubble in _bubbles)
        {
            bubble.GetComponentInChildren<Light2D>().enabled = false;
        }

        _nextBubble.gameObject.SetActive(false);
    }

    private void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
        foreach (Bubble bubble in _bubbles)
        {
            bubble.GetComponentInChildren<Light2D>().enabled = true;
        }
        _nextBubble.gameObject.SetActive(true);
    }

    private void OnBubbleCreated(BubbleCreated e)
    {
        _bubbles.Add(e.Bubble);
    }

    private void OnBubbleMerged(BubbleMerged e)
    {
        _bubbles.Remove(e.Bubble1);
        _bubbles.Remove(e.Bubble2);
    }

    private void Update()
    {
        if (_isPaused == false)
        {
            _cannon.UpdateExtended();
            _nextBubble.UpdateExtended();
        }
    }

    private void FixedUpdate()
    {
        if (_isPaused == false)
        {
            List<Bubble> bubblesOnHandling = new(_bubbles);

            foreach (Bubble b in bubblesOnHandling)
            {
                if (b != null)
                {
                    b.FixedUpdateExtended();
                }
            }
        }
    }

    private void OnGameRestarted(GameRestarted e)
    {
        SceneManager.LoadScene(0);
    }

    private void OnGameOver(GameOver e)
    {
        PauseGame();
        _gameOverMenu.gameObject.SetActive(true);
        _gameOverMenu.SetScore(_scoreCounter.GetScore());
    }
}
