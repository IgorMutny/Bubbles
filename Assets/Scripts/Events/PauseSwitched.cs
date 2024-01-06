public class PauseSwitched : IEvent
{
    public readonly bool State;

    public PauseSwitched(bool state)
    {
        State = state;
    }
}
