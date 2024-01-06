using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private readonly string _mainString = "явер\n";

    private TextMeshProUGUI _text;
    private int _score;

    public void Initialize()
    {
        EventBus.Subscribe<ScoreChanged>(OnScoreChanged);
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<ScoreChanged>(OnScoreChanged);
    }

    private void OnScoreChanged(ScoreChanged e)
    {
        _score = e.Value;
        _text.text = _mainString + _score.ToString();
    }
}
