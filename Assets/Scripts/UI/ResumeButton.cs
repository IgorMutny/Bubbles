using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void OnClick()
    {
        EventBus.Invoke(new ButtonClicked());
        YG.YandexGame.SaveProgress();
        EventBus.Invoke(new PauseSwitched(false));
        _menu.SetActive(false);
    }
}
