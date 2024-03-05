namespace MonogameTest01;

public abstract class ThirdAffector : Affector
{
    protected override IQueue.Position QueuePosition => IQueue.Position.Third;

    public ThirdAffector(Mechanics mechanics) : base(mechanics) { }
}
