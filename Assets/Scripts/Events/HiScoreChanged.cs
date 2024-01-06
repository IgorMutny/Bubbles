public class HiScoreChanged : IEvent
{
    public readonly int Value;

    public HiScoreChanged(int value)
    {
        Value = value;
    }
}
