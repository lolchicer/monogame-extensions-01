namespace MonogameTest01;

public abstract class SecondAffector : Affector
{
    protected override ISteppedQueue.Position QueuePosition => ISteppedQueue.Position.Second;

    public SecondAffector(Mechanics mechanics) : base(mechanics) { }
}
