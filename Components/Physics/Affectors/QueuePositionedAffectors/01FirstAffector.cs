namespace MonogameTest01;

public abstract class FirstAffector : Affector
{
    public override IQueue.Position QueuePosition => IQueue.Position.First;

    public FirstAffector(Mechanics mechanics) : base(mechanics) { }
}
