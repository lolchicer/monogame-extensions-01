namespace MonogameTest01;

public abstract class FirstAffector : Affector
{
    protected override ISteppedQueue.Position QueuePosition => ISteppedQueue.Position.First;

    public FirstAffector(Mechanics mechanics) : base(mechanics) { }
}
