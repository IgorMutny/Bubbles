public class BubbleCreated : IEvent
{
    public readonly Bubble Bubble;

    public BubbleCreated(Bubble bubble)
    {
        Bubble = bubble;
    }
}
