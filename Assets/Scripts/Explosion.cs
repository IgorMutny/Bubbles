using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _lifeTime = 10f;

    public void Initialize(Color color)
    {
        Destroy(gameObject, _lifeTime);
        SetColor(color);
        SetSound();
    }

    private void SetColor(Color color)
    {
        GradientAlphaKey[] alphas = new GradientAlphaKey[2];
        alphas[0] = new(1, 0);
        alphas[1] = new(0, 1);

        GradientColorKey[] colors = new GradientColorKey[2];
        colors[0] = new(color, 0);
        colors[1] = new(color, 1);

        Gradient gradient = new();
        gradient.SetKeys(colors, alphas);

        ParticleSystem.ColorOverLifetimeModule colorModule = GetComponent<ParticleSystem>().colorOverLifetime;
        colorModule.color = gradient;
    }

    private void SetSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = YG.YandexGame.savesData.Volume;
        audioSource.Play();
    }
}
