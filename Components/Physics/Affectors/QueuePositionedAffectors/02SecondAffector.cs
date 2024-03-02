namespace MonogameTest01;

public abstract class SecondAffector : Affector
{
    public override IQueue.Position QueuePosition => IQueue.Position.Second;

    public SecondAffector(Mechanics mechanics) : base(mechanics) { }
}
