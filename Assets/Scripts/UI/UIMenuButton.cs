using UnityEngine;

public class UIMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void OnClick()
    {
        _menu.SetActive(true);
        EventBus.Invoke(new ButtonClicked());
        EventBus.Invoke(new PauseSwitched(true));
    }
}
