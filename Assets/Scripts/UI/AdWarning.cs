using TMPro;
using UnityEngine;

public class AdWarning : MonoBehaviour
{
    private float _lifeTime;
    private TextMeshPro _textMeshPro;
    private int _secondsLeft;
    private string _mainText = "Реклама через \n";

    private void Update()
    {
        _lifeTime -= Time.unscaledDeltaTime;

        if (_secondsLeft != (int)Mathf.Ceil(_lifeTime))
        {
            _secondsLeft = (int)Mathf.Ceil(_lifeTime);
            SetText();
        }
    }

    public void Initialize(float lifeTime)
    {
        _lifeTime = lifeTime;
        _textMeshPro = GetComponent<TextMeshPro>();
        _secondsLeft = (int)Mathf.Ceil(_lifeTime);
        SetText();
    }

    private void SetText()
    {
        _textMeshPro.text = _mainText + _secondsLeft;
    }
}
