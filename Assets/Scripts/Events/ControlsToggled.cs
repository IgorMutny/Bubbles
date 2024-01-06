public class ControlsToggled : IEvent
{
    public readonly bool OneClickHandle;

    public ControlsToggled(bool oneClickHandle)
    {
        OneClickHandle = oneClickHandle;
    }
}
