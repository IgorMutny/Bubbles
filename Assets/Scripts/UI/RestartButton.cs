using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        EventBus.Invoke(new ButtonClicked());
        EventBus.Invoke(new GameRestarted());
    }
}
