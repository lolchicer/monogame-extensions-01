namespace MonogameTest01;

public abstract class FirstAffector : Affector
{
    public override AffectorsQueue.Position QueuePosition => AffectorsQueue.Position.First;

    public FirstAffector(Mechanics mechanics) : base(mechanics) { }
}
