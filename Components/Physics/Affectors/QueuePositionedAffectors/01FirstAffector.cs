namespace MonogameTest01;

public abstract class FirstAffector : Affector
{
    protected override IQueue.Position QueuePosition => IQueue.Position.First;

    public FirstAffector(Mechanics mechanics) : base(mechanics) { }
}
