namespace MonogameTest01;

public abstract class ThirdAffector : Affector
{
    public override IQueue.Position QueuePosition => IQueue.Position.Third;

    public ThirdAffector(Mechanics mechanics) : base(mechanics) { }
}
