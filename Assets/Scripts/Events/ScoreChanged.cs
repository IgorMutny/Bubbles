public class ScoreChanged : IEvent
{
    public readonly int Value;

    public ScoreChanged(int value)
    {
        Value = value;
    }
}
