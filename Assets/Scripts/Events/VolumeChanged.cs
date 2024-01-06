public class VolumeChanged : IEvent
{
    public readonly float Volume;

    public VolumeChanged(float volume)
    {
        Volume = volume;
    }
}
