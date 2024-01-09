namespace MonogameTest01;

public abstract class SecondAffector : Affector
{
    public override AffectorsQueue.Position QueuePosition => AffectorsQueue.Position.Second;

    public SecondAffector(Mechanics mechanics) : base(mechanics) { }
}
