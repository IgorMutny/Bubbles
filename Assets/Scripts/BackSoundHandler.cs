using UnityEngine;

public class BackSoundHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Initialize()
    {
        EventBus.Subscribe<VolumeChanged>(OnVolumeChanged);

        _audioSource = GetComponent<AudioSource>();
        SetVolume(YG.YandexGame.savesData.Volume);
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<VolumeChanged>(OnVolumeChanged);
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
