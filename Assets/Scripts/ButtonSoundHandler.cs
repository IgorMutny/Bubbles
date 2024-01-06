using UnityEngine;

public class ButtonSoundHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Initialize()
    {
        _audioSource = GetComponent<AudioSource>();
        SetVolume(YG.YandexGame.savesData.Volume);
        EventBus.Subscribe<ButtonClicked>(OnButtonClicked);
        EventBus.Subscribe<VolumeChanged>(OnVolumeChanged);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<ButtonClicked>(OnButtonClicked);
        EventBus.Unsubscribe<VolumeChanged>(OnVolumeChanged);
    }

    private void OnButtonClicked(ButtonClicked e)
    {
        _audioSource.Play();
    }

    private void OnVolumeChanged(VolumeChanged e)
    {
        SetVolume(e.Volume);
    }

    private void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
