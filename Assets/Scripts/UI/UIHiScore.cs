using TMPro;
using UnityEngine;

public class UIHiScore : MonoBehaviour
{
    private readonly string _mainString = "ÐÅÊÎÐÄ\n";

    private TextMeshProUGUI _text;
    private int _score;

    public void Initialize()
    {
        EventBus.Subscribe<HiScoreChanged>(OnHiScoreChanged);
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<HiScoreChanged>(OnHiScoreChanged);
    }

    private void OnHiScoreChanged(HiScoreChanged e)
    {
        _score = e.Value;
        _text.text = _mainString + _score.ToString();
    }
}
