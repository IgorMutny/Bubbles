using UnityEngine;

public class BubbleCreating : IEvent
{
    public readonly Vector2 Position;
    public readonly int Size;

    public BubbleCreating(Vector2 position, int size)
    {
        Position = position;
        Size = size;
    }
}
