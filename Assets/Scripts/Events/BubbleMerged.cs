public class BubbleMerged : IEvent
{
    public readonly Bubble Bubble1;
    public readonly Bubble Bubble2;

    public BubbleMerged(Bubble bubble1, Bubble bubble2)
    {
        Bubble1 = bubble1;
        Bubble2 = bubble2;
    }
}
