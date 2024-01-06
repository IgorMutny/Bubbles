using UnityEngine;

public class BubbleMerging : IEvent
{
    public readonly Vector2 Position;
    public readonly int Size;
    public readonly Bubble Bubble1;
    public readonly Bubble Bubble2;

    public BubbleMerging(Vector2 position, int size, Bubble bubble1, Bubble bubble2)
    {
        Position = position;
        Size = size;
        Bubble1 = bubble1;
        Bubble2 = bubble2;
    }
}
