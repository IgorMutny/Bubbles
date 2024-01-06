using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;
    private int _hiScore;

    public void Initialize()
    {
        _hiScore = YG.YandexGame.savesData.HiScore;
        EventBus.Subscribe<BubbleMerging>(OnBubbleMerged);
        EventBus.Invoke(new ScoreChanged(_score));
        EventBus.Invoke(new HiScoreChanged(_hiScore));
    }

    public int GetScore()
    {
        return _score;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<BubbleMerging>(OnBubbleMerged);
        YG.YandexGame.savesData.HiScore = _hiScore;
        YG.YandexGame.SaveProgress();
    }

    private void OnBubbleMerged(BubbleMerging e)
    {
        _score += e.Size - 1;
        EventBus.Invoke(new ScoreChanged(_score));
        if (_score > _hiScore)
        {
            _hiScore = _score;
            EventBus.Invoke(new HiScoreChanged(_hiScore));
            YG.YandexGame.savesData.HiScore = _hiScore;
            YG.YandexGame.SaveProgress();
        }
    }

}
