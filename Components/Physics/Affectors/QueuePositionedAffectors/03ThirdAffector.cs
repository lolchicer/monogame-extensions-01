namespace MonogameTest01;

public abstract class ThirdAffector : Affector
{
    protected override ISteppedQueue.Position QueuePosition => ISteppedQueue.Position.Third;

    public ThirdAffector(Mechanics mechanics) : base(mechanics) { }
}
