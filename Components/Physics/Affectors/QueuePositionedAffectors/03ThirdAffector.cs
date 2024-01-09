namespace MonogameTest01;

public abstract class ThirdAffector : Affector
{
    public override AffectorsQueue.Position QueuePosition => AffectorsQueue.Position.Third;

    public ThirdAffector(Mechanics mechanics) : base(mechanics) { }
}
