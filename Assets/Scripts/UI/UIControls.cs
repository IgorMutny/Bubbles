using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    [SerializeField] private Toggle _oneClick;
    [SerializeField] private Toggle _dragAndDrop;

    public void Initialize()
    {
        bool oneClickHandle = YG.YandexGame.savesData.OneClickHandle;

        _oneClick.isOn = oneClickHandle;
        _dragAndDrop.isOn = !oneClickHandle;
    }

    public void OneClickToggled()
    {
        EventBus.Invoke(new ButtonClicked());
        YG.YandexGame.savesData.OneClickHandle = true;
        _dragAndDrop.isOn = false;
        EventBus.Invoke(new ControlsToggled(true));
    }

    public void DragAndDropToggled()
    {
        EventBus.Invoke(new ButtonClicked());
        YG.YandexGame.savesData.OneClickHandle = false;
        _oneClick.isOn = false;
        EventBus.Invoke(new ControlsToggled(false));
    }
}
