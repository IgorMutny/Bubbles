using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = YG.YandexGame.savesData.Volume;
    }

    public void OnValueChanged()
    {
        YG.YandexGame.savesData.Volume = _slider.value;
        EventBus.Invoke(new ButtonClicked());
        EventBus.Invoke(new VolumeChanged(_slider.value));
    }
}
