namespace MonogameTest01;

public abstract class SecondAffector : Affector
{
    protected override IQueue.Position QueuePosition => IQueue.Position.Second;

    public SecondAffector(Mechanics mechanics) : base(mechanics) { }
}
